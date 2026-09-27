using Microsoft.AspNetCore.Mvc;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class TestController : Controller
{
    private readonly PayrollRepository _repository;

    public TestController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Oracle()
    {
        var result = await _repository.TestAdminConnectionAsync();
        return View(new OracleTestViewModel
        {
            Success = result.Success,
            Message = result.Message,
            DataSource = _repository.DataSource,
            SchemaOwner = _repository.SchemaOwner,
            DepartmentCount = result.DepartmentCount
        });
    }

    [HttpGet]
    public IActionResult Error()
    {
        return Content("An unexpected error occurred. Enable Development mode to see detailed errors.");
    }
}
