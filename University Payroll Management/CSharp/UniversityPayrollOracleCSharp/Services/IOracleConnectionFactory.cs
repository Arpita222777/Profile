using Oracle.ManagedDataAccess.Client;

namespace UniversityPayrollOracleCSharp.Services;

public interface IOracleConnectionFactory
{
    string DataSource { get; }
    string SchemaOwner { get; }
    Task<OracleConnection> CreateConnectionAsync(string username, string password);
    Task<OracleConnection> CreateAdminConnectionAsync();
    string DbObject(string objectName);
    string Sequence(string sequenceName);
}
