using System.ComponentModel.DataAnnotations;

namespace UniversityPayrollOracleCSharp.Models;

public sealed class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PayrollBudget { get; set; }
    public int DeanId { get; set; }
    public string DeanName { get; set; } = string.Empty;
    public string DeanEmail { get; set; } = string.Empty;
}

public sealed class DepartmentForm
{
    [Required]
    [Display(Name = "Department Name")]
    public string DepartmentName { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Payroll budget must be 0 or more.")]
    [Display(Name = "Payroll Budget")]
    public decimal PayrollBudget { get; set; }

    [Required]
    [Display(Name = "Dean Name")]
    public string DeanName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [Display(Name = "Dean Email")]
    public string DeanEmail { get; set; } = string.Empty;
}

public sealed class SetupViewModel
{
    public DepartmentForm Form { get; set; } = new();
    public List<DepartmentDto> Departments { get; set; } = new();
    public List<UserRoleDto> Users { get; set; } = new();
    public List<DesignationDto> Designations { get; set; } = new();
    public string? Message { get; set; }
    public bool Success { get; set; }
}
