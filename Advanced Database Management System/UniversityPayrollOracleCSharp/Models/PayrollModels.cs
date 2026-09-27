using System.ComponentModel.DataAnnotations;

namespace UniversityPayrollOracleCSharp.Models;

public sealed class PayrollStaffDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public sealed class FinanceOfficerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public sealed class PayrollForm
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a faculty member.")]
    [Display(Name = "Faculty")]
    public int FacultyId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Payment Date")]
    public DateTime PaymentDate { get; set; } = DateTime.Today;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Base salary must be greater than 0.")]
    [Display(Name = "Base Salary")]
    public decimal BaseSalary { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Allowances { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Deductions { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Tax { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select payroll staff.")]
    [Display(Name = "Payroll Staff")]
    public int PayrollStaffId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a finance officer.")]
    [Display(Name = "Finance Officer")]
    public int FinanceOfficerId { get; set; }
}

public sealed class PayrollEntryViewModel
{
    public PayrollForm Form { get; set; } = new();
    public List<FacultyDto> Faculty { get; set; } = new();
    public List<PayrollStaffDto> PayrollStaff { get; set; } = new();
    public List<FinanceOfficerDto> FinanceOfficers { get; set; } = new();
    public string? Message { get; set; }
    public bool Success { get; set; }
}
