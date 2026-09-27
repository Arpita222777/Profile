using System.ComponentModel.DataAnnotations;

namespace UniversityPayrollOracleCSharp.Models;

public sealed class LoginViewModel
{
    [Required]
    [Display(Name = "Oracle Username")]
    public string Username { get; set; } = "upms_admin";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "admin123";

    [Required]
    public string Role { get; set; } = "Admin";

    public string? ErrorMessage { get; set; }
}
