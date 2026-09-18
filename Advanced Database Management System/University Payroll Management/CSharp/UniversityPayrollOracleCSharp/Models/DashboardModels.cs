namespace UniversityPayrollOracleCSharp.Models;

public sealed class ActivityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public sealed class DashboardViewModel
{
    public int FacultyCount { get; set; }
    public decimal MonthlyPayrollTotal { get; set; }
    public int PayrollTransactionCount { get; set; }
    public int DepartmentCount { get; set; }
    public List<ActivityDto> RecentActivities { get; set; } = new();
    public List<FacultyDto> RecentFaculty { get; set; } = new();
}
