namespace UniversityPayrollOracleCSharp.Models;

public sealed class ReportRowDto
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public int FacultyCount { get; set; }
    public decimal TotalSalary { get; set; }
    public decimal AverageSalary { get; set; }
}

public sealed class ReportsViewModel
{
    public string Month { get; set; } = DateTime.Today.ToString("MMMM");
    public int MonthNumber { get; set; } = DateTime.Today.Month;
    public int Year { get; set; } = DateTime.Today.Year;
    public string Search { get; set; } = string.Empty;
    public List<ReportRowDto> Rows { get; set; } = new();
    public int TotalFaculty => Rows.Sum(r => r.FacultyCount);
    public decimal TotalPayroll => Rows.Sum(r => r.TotalSalary);
    public decimal AverageSalary => TotalFaculty > 0 ? Rows.Sum(r => r.TotalSalary) / TotalFaculty : 0;
}
