using Microsoft.AspNetCore.Mvc;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class DashboardController : AppController
{
    private readonly PayrollRepository _repository;

    public DashboardController(PayrollRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        if (!IsLoggedIn) return LoginRedirect();
        var model = await _repository.GetDashboardAsync();
        return View(model);
    }
}
