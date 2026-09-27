using System.ComponentModel.DataAnnotations;

namespace UniversityPayrollOracleCSharp.Models;

public sealed class FacultyDto
{
    public int Id { get; set; }
    public string FacultyName { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string AcademicRank { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string BankInfo { get; set; } = string.Empty;
    public decimal ResearchAllowance { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
}

public sealed class FacultyForm
{
    [Required]
    [Display(Name = "Faculty Name")]
    public string FacultyName { get; set; } = string.Empty;

    [Required]
    public string Designation { get; set; } = "Professor";

    [Required]
    [Display(Name = "Academic Rank")]
    public string AcademicRank { get; set; } = "Senior";

    [Required]
    [EmailAddress]
    [Display(Name = "Faculty Email")]
    public string FacultyEmail { get; set; } = string.Empty;

    [Display(Name = "Phone")]
    public string? Phone { get; set; }

    [Required]
    [Display(Name = "Bank Information")]
    public string BankInfo { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Research allowance must be 0 or more.")]
    [Display(Name = "Research Allowance")]
    public decimal ResearchAllowance { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a department.")]
    [Display(Name = "Department")]
    public int DepartmentId { get; set; }
}

public sealed class FacultyListViewModel
{
    public List<FacultyDto> Faculty { get; set; } = new();
}

public sealed class AddFacultyViewModel
{
    public FacultyForm Form { get; set; } = new();
    public List<DepartmentDto> Departments { get; set; } = new();
    public List<DesignationDto> Designations { get; set; } = new();
    public string? Message { get; set; }
    public bool Success { get; set; }
}
