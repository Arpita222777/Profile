using Oracle.ManagedDataAccess.Client;
using UniversityPayrollOracleCSharp.Models;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;

namespace UniversityPayrollOracleCSharp.Services;

public sealed class PayrollRepository
{
    private readonly IOracleConnectionFactory _factory;

    public PayrollRepository(IOracleConnectionFactory factory)
    {
        _factory = factory;
    }

    public string DataSource => _factory.DataSource;
    public string SchemaOwner => _factory.SchemaOwner;

    public async Task<AppUser?> LoginAsync(string username, string password, string selectedRole)
    {
        var normalizedUser = (username ?? string.Empty).Trim().ToUpperInvariant();
        var oracleRole = RoleToOracleRole(selectedRole);
        if (string.IsNullOrWhiteSpace(normalizedUser) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(oracleRole))
        {
            return null;
        }

        try
        {
            using var connection = await _factory.CreateConnectionAsync(normalizedUser, password);
            using var command = connection.CreateCommand();
            command.BindByName = true;
            command.CommandText = @"
                select count(*)
                from (
                    select role from session_roles
                    union
                    select granted_role as role from user_role_privs
                )
                where role = :role_name";
            command.Parameters.Add(Param("role_name", OracleDbType.Varchar2, oracleRole));
            var count = ToInt(await command.ExecuteScalarAsync());
            if (count <= 0)
            {
                return null;
            }

            return new AppUser
            {
                Username = normalizedUser,
                Name = FormatOracleUsername(normalizedUser),
                Role = selectedRole
            };
        }
        catch (OracleException)
        {
            return null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public List<UserRoleDto> GetConfiguredUsers()
    {
        return new List<UserRoleDto>
        {
            new() { Name = "UPMS Admin", Username = "upms_admin", Role = "Admin / ADMIN_ROLE" },
            new() { Name = "UPMS Operator", Username = "upms_operator", Role = "Payroll Staff / ENTRY_ROLE" },
            new() { Name = "UPMS Auditor", Username = "upms_auditor", Role = "Auditor / VIEWER_ROLE" }
        };
    }

    public List<DesignationDto> GetDesignations()
    {
        return new List<DesignationDto>
        {
            new() { Id = "Professor", Title = "Professor" },
            new() { Id = "Asst. Professor", Title = "Asst. Professor" },
            new() { Id = "Lecturer", Title = "Lecturer" },
            new() { Id = "Dean", Title = "Dean" }
        };
    }

    public async Task<DashboardViewModel> GetDashboardAsync()
    {
        return new DashboardViewModel
        {
            FacultyCount = await CountFacultyAsync(),
            MonthlyPayrollTotal = await GetMonthlyPayrollTotalAsync(),
            PayrollTransactionCount = await CountPayrollTransactionsAsync(),
            DepartmentCount = await CountDepartmentsAsync(),
            RecentActivities = await GetRecentActivitiesAsync(6),
            RecentFaculty = await GetFacultyListAsync(5)
        };
    }

    public async Task<List<DepartmentDto>> GetDepartmentsAsync()
    {
        var sql = $@"
            select d.department_id as id,
                   d.department_name as name,
                   d.payroll_budget,
                   d.dean_id,
                   de.dean_name,
                   de.dean_email
            from {_factory.DbObject("department")} d
            left join {_factory.DbObject("dean")} de on d.dean_id = de.dean_id
            order by d.department_name asc";

        return await QueryAsync(sql, reader => new DepartmentDto
        {
            Id = ToInt(reader["id"]),
            Name = ToStringValue(reader["name"]),
            PayrollBudget = ToDecimal(reader["payroll_budget"]),
            DeanId = ToInt(reader["dean_id"]),
            DeanName = ToStringValue(reader["dean_name"]),
            DeanEmail = ToStringValue(reader["dean_email"])
        });
    }

    public async Task<int> AddDepartmentAsync(DepartmentForm form)
    {
        using var connection = await _factory.CreateAdminConnectionAsync();
        using var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            var deanId = await FindDeanIdByEmailAsync(connection, transaction, form.DeanEmail);
            if (deanId == 0)
            {
                deanId = await NextIdAsync(connection, transaction, "seq_dean");
                using var deanCommand = connection.CreateCommand();
                deanCommand.BindByName = true;
                deanCommand.Transaction = transaction;
                deanCommand.CommandText = $@"
                    insert into {_factory.DbObject("dean")}(dean_id, dean_name, dean_email)
                    values(:dean_id, :dean_name, :dean_email)";
                deanCommand.Parameters.Add(Param("dean_id", OracleDbType.Int32, deanId));
                deanCommand.Parameters.Add(Param("dean_name", OracleDbType.Varchar2, form.DeanName));
                deanCommand.Parameters.Add(Param("dean_email", OracleDbType.Varchar2, form.DeanEmail));
                await deanCommand.ExecuteNonQueryAsync();
            }

            var departmentId = await NextIdAsync(connection, transaction, "seq_department");
            using var deptCommand = connection.CreateCommand();
            deptCommand.BindByName = true;
            deptCommand.Transaction = transaction;
            deptCommand.CommandText = $@"
                insert into {_factory.DbObject("department")}(department_id, department_name, payroll_budget, dean_id)
                values(:department_id, :department_name, :payroll_budget, :dean_id)";
            deptCommand.Parameters.Add(Param("department_id", OracleDbType.Int32, departmentId));
            deptCommand.Parameters.Add(Param("department_name", OracleDbType.Varchar2, form.DepartmentName));
            deptCommand.Parameters.Add(Param("payroll_budget", OracleDbType.Decimal, form.PayrollBudget));
            deptCommand.Parameters.Add(Param("dean_id", OracleDbType.Int32, deanId));
            await deptCommand.ExecuteNonQueryAsync();

            await TryAddActivityLogAsync(connection, transaction, "INSERT", "DEPARTMENT", $"Department added: {form.DepartmentName}");
            transaction.Commit();
            return departmentId;
        }
        catch
        {
            TryRollback(transaction);
            throw;
        }
    }

    public async Task<List<FacultyDto>> GetFacultyListAsync(int limit = 0)
    {
        var baseSql = FacultySelectSql() + " order by f.faculty_id desc";
        var parameters = new List<OracleParameter>();
        var sql = baseSql;
        if (limit > 0)
        {
            sql = $"select * from ({baseSql}) where rownum <= :row_limit";
            parameters.Add(Param("row_limit", OracleDbType.Int32, limit));
        }

        return await QueryAsync(sql, MapFaculty, parameters.ToArray());
    }

    public async Task<List<FacultyDto>> GetActiveFacultyListAsync()
    {
        return await QueryAsync(FacultySelectSql() + " order by f.faculty_name asc", MapFaculty);
    }

    public async Task<int> AddFacultyAsync(FacultyForm form)
    {
        using var connection = await _factory.CreateAdminConnectionAsync();
        using var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            var facultyId = await NextIdAsync(connection, transaction, "seq_faculty");
            using var command = connection.CreateCommand();
            command.BindByName = true;
            command.Transaction = transaction;
            command.CommandText = $@"
                insert into {_factory.DbObject("faculty")}
                    (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id)
                values
                    (:faculty_id, :faculty_name, :designation, :academic_rank, :faculty_email, :bank_info, :research_allowance, :department_id)";
            command.Parameters.Add(Param("faculty_id", OracleDbType.Int32, facultyId));
            command.Parameters.Add(Param("faculty_name", OracleDbType.Varchar2, form.FacultyName));
            command.Parameters.Add(Param("designation", OracleDbType.Varchar2, form.Designation));
            command.Parameters.Add(Param("academic_rank", OracleDbType.Varchar2, form.AcademicRank));
            command.Parameters.Add(Param("faculty_email", OracleDbType.Varchar2, form.FacultyEmail));
            command.Parameters.Add(Param("bank_info", OracleDbType.Varchar2, form.BankInfo));
            command.Parameters.Add(Param("research_allowance", OracleDbType.Decimal, form.ResearchAllowance));
            command.Parameters.Add(Param("department_id", OracleDbType.Int32, form.DepartmentId));
            await command.ExecuteNonQueryAsync();

            if (!string.IsNullOrWhiteSpace(form.Phone))
            {
                var phoneId = await NextIdAsync(connection, transaction, "seq_faculty_phone");
                using var phoneCommand = connection.CreateCommand();
                phoneCommand.BindByName = true;
                phoneCommand.Transaction = transaction;
                phoneCommand.CommandText = $@"
                    insert into {_factory.DbObject("faculty_phone")}(faculty_phone_id, faculty_id, phone)
                    values(:faculty_phone_id, :faculty_id, :phone)";
                phoneCommand.Parameters.Add(Param("faculty_phone_id", OracleDbType.Int32, phoneId));
                phoneCommand.Parameters.Add(Param("faculty_id", OracleDbType.Int32, facultyId));
                phoneCommand.Parameters.Add(Param("phone", OracleDbType.Varchar2, form.Phone));
                await phoneCommand.ExecuteNonQueryAsync();
            }

            await TryAddActivityLogAsync(connection, transaction, "INSERT", "FACULTY", $"Faculty added: {form.FacultyName}");
            transaction.Commit();
            return facultyId;
        }
        catch
        {
            TryRollback(transaction);
            throw;
        }
    }

    public async Task<List<PayrollStaffDto>> GetPayrollStaffListAsync()
    {
        var sql = $@"
            select payroll_staff_id as id, staff_name as name, staff_email as email
            from {_factory.DbObject("payroll_staff")}
            order by staff_name asc";
        return await QueryAsync(sql, reader => new PayrollStaffDto
        {
            Id = ToInt(reader["id"]),
            Name = ToStringValue(reader["name"]),
            Email = ToStringValue(reader["email"])
        });
    }

    public async Task<List<FinanceOfficerDto>> GetFinanceOfficerListAsync()
    {
        var sql = $@"
            select finance_officer_id as id, officer_name as name, officer_email as email
            from {_factory.DbObject("finance_officer")}
            order by officer_name asc";
        return await QueryAsync(sql, reader => new FinanceOfficerDto
        {
            Id = ToInt(reader["id"]),
            Name = ToStringValue(reader["name"]),
            Email = ToStringValue(reader["email"])
        });
    }

    public async Task<int> AddPayrollTransactionAsync(PayrollForm form)
    {
        using var connection = await _factory.CreateAdminConnectionAsync();
        using var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            var netSalary = form.BaseSalary + form.Allowances - form.Deductions - form.Tax;
            if (netSalary < 0)
            {
                netSalary = 0;
            }

            var transactionId = await NextIdAsync(connection, transaction, "seq_payroll_transaction");
            using var command = connection.CreateCommand();
            command.BindByName = true;
            command.Transaction = transaction;
            command.CommandText = $@"
                insert into {_factory.DbObject("payroll_transaction")}
                    (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id)
                values
                    (:transaction_id, :payment_date, :base_salary, :allowances, :deductions, :tax, :net_salary, :faculty_id, :payroll_staff_id, :finance_officer_id)";
            command.Parameters.Add(Param("transaction_id", OracleDbType.Int32, transactionId));
            command.Parameters.Add(Param("payment_date", OracleDbType.Date, form.PaymentDate.Date));
            command.Parameters.Add(Param("base_salary", OracleDbType.Decimal, form.BaseSalary));
            command.Parameters.Add(Param("allowances", OracleDbType.Decimal, form.Allowances));
            command.Parameters.Add(Param("deductions", OracleDbType.Decimal, form.Deductions));
            command.Parameters.Add(Param("tax", OracleDbType.Decimal, form.Tax));
            command.Parameters.Add(Param("net_salary", OracleDbType.Decimal, netSalary));
            command.Parameters.Add(Param("faculty_id", OracleDbType.Int32, form.FacultyId));
            command.Parameters.Add(Param("payroll_staff_id", OracleDbType.Int32, form.PayrollStaffId));
            command.Parameters.Add(Param("finance_officer_id", OracleDbType.Int32, form.FinanceOfficerId));
            await command.ExecuteNonQueryAsync();

            await TryAddActivityLogAsync(connection, transaction, "INSERT", "PAYROLL_TRANSACTION", $"Payroll processed. Net salary: {netSalary.ToString("0.00", CultureInfo.InvariantCulture)}");
            transaction.Commit();
            return transactionId;
        }
        catch
        {
            TryRollback(transaction);
            throw;
        }
    }

    public async Task<List<ReportRowDto>> GetReportSummaryAsync(int monthNumber, int year, string? search)
    {
        var parameters = new List<OracleParameter>
        {
            Param("month_number", OracleDbType.Int32, monthNumber),
            Param("year_number", OracleDbType.Int32, year)
        };
        var where = string.Empty;
        if (!string.IsNullOrWhiteSpace(search))
        {
            where = "where lower(d.department_name) like :search_text";
            parameters.Add(Param("search_text", OracleDbType.Varchar2, $"%{search.Trim().ToLowerInvariant()}%"));
        }

        var sql = $@"
            select d.department_id as department_id,
                   d.department_name as department_name,
                   count(distinct f.faculty_id) as faculty_count,
                   nvl(sum(pt.net_salary), 0) as total_salary,
                   nvl(avg(pt.net_salary), 0) as average_salary
            from {_factory.DbObject("department")} d
            left join {_factory.DbObject("faculty")} f on d.department_id = f.department_id
            left join {_factory.DbObject("payroll_transaction")} pt
                   on f.faculty_id = pt.faculty_id
                  and extract(month from pt.payment_date) = :month_number
                  and extract(year from pt.payment_date) = :year_number
            {where}
            group by d.department_id, d.department_name
            order by d.department_id asc";

        return await QueryAsync(sql, reader => new ReportRowDto
        {
            DepartmentId = ToInt(reader["department_id"]),
            DepartmentName = ToStringValue(reader["department_name"]),
            FacultyCount = ToInt(reader["faculty_count"]),
            TotalSalary = ToDecimal(reader["total_salary"]),
            AverageSalary = ToDecimal(reader["average_salary"])
        }, parameters.ToArray());
    }

    public async Task<(bool Success, string Message, int DepartmentCount)> TestAdminConnectionAsync()
    {
        try
        {
            var departments = await CountDepartmentsAsync();
            return (true, "Oracle connection succeeded and the application can read the DEPARTMENT table.", departments);
        }
        catch (Exception ex)
        {
            return (false, ex.Message, 0);
        }
    }

    private string FacultySelectSql()
    {
        return $@"
            select f.faculty_id as id,
                   f.faculty_name,
                   f.designation,
                   f.academic_rank,
                   f.faculty_email as email,
                   f.bank_info,
                   f.research_allowance,
                   f.department_id,
                   d.department_name
            from {_factory.DbObject("faculty")} f
            left join {_factory.DbObject("department")} d on f.department_id = d.department_id";
    }

    private static FacultyDto MapFaculty(DbDataReader reader)
    {
        return new FacultyDto
        {
            Id = ToInt(reader["id"]),
            FacultyName = ToStringValue(reader["faculty_name"]),
            Designation = ToStringValue(reader["designation"]),
            AcademicRank = ToStringValue(reader["academic_rank"]),
            Email = ToStringValue(reader["email"]),
            BankInfo = ToStringValue(reader["bank_info"]),
            ResearchAllowance = ToDecimal(reader["research_allowance"]),
            DepartmentId = ToInt(reader["department_id"]),
            DepartmentName = ToStringValue(reader["department_name"])
        };
    }

    private async Task<int> CountFacultyAsync()
    {
        return ToInt(await ScalarAsync($"select count(*) from {_factory.DbObject("faculty")}"));
    }

    private async Task<decimal> GetMonthlyPayrollTotalAsync()
    {
        return ToDecimal(await ScalarAsync($"select nvl(sum(net_salary), 0) from {_factory.DbObject("payroll_transaction")} where trunc(payment_date, 'MM') = trunc(sysdate, 'MM')"));
    }

    private async Task<int> CountPayrollTransactionsAsync()
    {
        return ToInt(await ScalarAsync($"select count(*) from {_factory.DbObject("payroll_transaction")}"));
    }

    private async Task<int> CountDepartmentsAsync()
    {
        return ToInt(await ScalarAsync($"select count(*) from {_factory.DbObject("department")}"));
    }

    private async Task<List<ActivityDto>> GetRecentActivitiesAsync(int limit)
    {
        var sql = $@"
            select * from (
                select log_id as id,
                       action_name as title,
                       remarks as description,
                       action_time as created_at
                from {_factory.DbObject("payroll_audit_log")}
                order by log_id desc
            ) where rownum <= :row_limit";

        return await QueryAsync(sql, reader => new ActivityDto
        {
            Id = ToInt(reader["id"]),
            Title = ToStringValue(reader["title"]),
            Description = ToStringValue(reader["description"]),
            CreatedAt = ToDate(reader["created_at"])
        }, Param("row_limit", OracleDbType.Int32, limit));
    }

    private async Task<int> FindDeanIdByEmailAsync(OracleConnection connection, OracleTransaction transaction, string email)
    {
        using var command = connection.CreateCommand();
        command.BindByName = true;
        command.Transaction = transaction;
        command.CommandText = $"select dean_id from {_factory.DbObject("dean")} where lower(dean_email) = lower(:dean_email) and rownum <= 1";
        command.Parameters.Add(Param("dean_email", OracleDbType.Varchar2, email));
        return ToInt(await command.ExecuteScalarAsync());
    }

    private async Task<int> NextIdAsync(OracleConnection connection, OracleTransaction transaction, string sequenceName)
    {
        using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = $"select {_factory.Sequence(sequenceName)}.nextval from dual";
        return ToInt(await command.ExecuteScalarAsync());
    }

    private async Task TryAddActivityLogAsync(OracleConnection connection, OracleTransaction transaction, string action, string tableName, string remarks)
    {
        try
        {
            var id = await NextIdAsync(connection, transaction, "seq_payroll_audit_log");
            using var command = connection.CreateCommand();
            command.BindByName = true;
            command.Transaction = transaction;
            command.CommandText = $@"
                insert into {_factory.DbObject("payroll_audit_log")}(log_id, action_name, table_name, action_time, remarks)
                values(:log_id, :action_name, :table_name, sysdate, :remarks)";
            command.Parameters.Add(Param("log_id", OracleDbType.Int32, id));
            command.Parameters.Add(Param("action_name", OracleDbType.Varchar2, action));
            command.Parameters.Add(Param("table_name", OracleDbType.Varchar2, tableName));
            command.Parameters.Add(Param("remarks", OracleDbType.Varchar2, remarks));
            await command.ExecuteNonQueryAsync();
        }
        catch
        {
            // Audit logging is helpful, but it must not block the main save action.
        }
    }

    private async Task<object?> ScalarAsync(string sql, params OracleParameter[] parameters)
    {
        using var connection = await _factory.CreateAdminConnectionAsync();
        using var command = connection.CreateCommand();
        command.BindByName = true;
        command.CommandText = sql;
        foreach (var parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }
        return await command.ExecuteScalarAsync();
    }

    private async Task<List<T>> QueryAsync<T>(string sql, Func<DbDataReader, T> map, params OracleParameter[] parameters)
    {
        using var connection = await _factory.CreateAdminConnectionAsync();
        using var command = connection.CreateCommand();
        command.BindByName = true;
        command.CommandText = sql;
        foreach (var parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }

        var rows = new List<T>();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            rows.Add(map(reader));
        }
        return rows;
    }

    private static OracleParameter Param(string name, OracleDbType type, object? value)
    {
        return new OracleParameter(name, type)
        {
            Value = value ?? DBNull.Value
        };
    }

    private static string RoleToOracleRole(string role)
    {
        return (role ?? string.Empty).Trim() switch
        {
            "Admin" => "ADMIN_ROLE",
            "Payroll Staff" => "ENTRY_ROLE",
            "Auditor" => "VIEWER_ROLE",
            _ => string.Empty
        };
    }

    private static string FormatOracleUsername(string username)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(username.Replace('_', ' ').ToLowerInvariant());
    }

    private static int ToInt(object? value)
    {
        if (value is null || value == DBNull.Value)
        {
            return 0;
        }
        return Convert.ToInt32(value, CultureInfo.InvariantCulture);
    }

    private static decimal ToDecimal(object? value)
    {
        if (value is null || value == DBNull.Value)
        {
            return 0m;
        }
        return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
    }

    private static string ToStringValue(object? value)
    {
        return value is null || value == DBNull.Value ? string.Empty : Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
    }

    private static DateTime ToDate(object? value)
    {
        if (value is null || value == DBNull.Value)
        {
            return DateTime.MinValue;
        }
        return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
    }

    private static void TryRollback(OracleTransaction transaction)
    {
        try
        {
            transaction.Rollback();
        }
        catch
        {
            // Nothing useful can be done here; preserve the original exception.
        }
    }

    public static string BuildCsv(IEnumerable<ReportRowDto> rows)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Department,Faculty Count,Total Salary,Average Salary");
        foreach (var row in rows)
        {
            sb.AppendLine(string.Join(',',
                Csv(row.DepartmentName),
                row.FacultyCount.ToString(CultureInfo.InvariantCulture),
                row.TotalSalary.ToString("0.00", CultureInfo.InvariantCulture),
                row.AverageSalary.ToString("0.00", CultureInfo.InvariantCulture)));
        }
        return sb.ToString();
    }

    private static string Csv(string value)
    {
        var escaped = (value ?? string.Empty).Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }
}
