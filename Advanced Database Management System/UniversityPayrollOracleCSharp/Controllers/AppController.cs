using Microsoft.AspNetCore.Mvc;

namespace UniversityPayrollOracleCSharp.Controllers;

public abstract class AppController : Controller
{
    protected bool IsLoggedIn => !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserName"));
    protected string CurrentRole => HttpContext.Session.GetString("UserRole") ?? string.Empty;
    protected string CurrentUserName => HttpContext.Session.GetString("UserName") ?? string.Empty;

    protected IActionResult LoginRedirect()
    {
        return RedirectToAction("Login", "Account");
    }

    protected bool RoleAllowed(params string[] roles)
    {
        return roles.Contains(CurrentRole, StringComparer.OrdinalIgnoreCase);
    }

    protected IActionResult AccessDenied()
    {
        TempData["Error"] = "You do not have permission to open that page.";
        return RedirectToAction("Index", "Dashboard");
    }
}
