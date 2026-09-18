namespace UniversityPayrollOracleCSharp.Services;

public sealed class OracleOptions
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 1521;
    public string Database { get; set; } = "XE";
    public string ConnectType { get; set; } = "SID";
    public string SchemaOwner { get; set; } = "UPMS_ADMIN";
    public string AdminUser { get; set; } = "upms_admin";
    public string AdminPassword { get; set; } = "admin123";
}
