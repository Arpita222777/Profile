using Microsoft.AspNetCore.Mvc;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class AccountController : AppController
{
    private readonly PayrollRepository _repository;

    public AccountController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (IsLoggedIn)
        {
            return RedirectToAction("Index", "Dashboard");
        }
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _repository.LoginAsync(model.Username, model.Password, model.Role);
        if (user is null)
        {
            model.ErrorMessage = "Login failed. Check Oracle username, password, selected role, and database connection settings.";
            return View(model);
        }

        HttpContext.Session.SetString("UserName", user.Username);
        HttpContext.Session.SetString("DisplayName", user.Name);
        HttpContext.Session.SetString("UserRole", user.Role);
        return RedirectToAction("Index", "Dashboard");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
