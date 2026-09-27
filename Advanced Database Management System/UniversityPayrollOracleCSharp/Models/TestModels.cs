namespace UniversityPayrollOracleCSharp.Models;

public sealed class OracleTestViewModel
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string DataSource { get; set; } = string.Empty;
    public string SchemaOwner { get; set; } = string.Empty;
    public int DepartmentCount { get; set; }
}
