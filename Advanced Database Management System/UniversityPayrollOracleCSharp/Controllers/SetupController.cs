using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class SetupController : AppController
{
    private readonly PayrollRepository _repository;

    public SetupController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin")) return AccessDenied();
        return View(await BuildViewModelAsync(new DepartmentForm()));
    }

    [HttpPost]
    public async Task<IActionResult> AddDepartment([Bind(Prefix = "Form")] DepartmentForm form)
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin")) return AccessDenied();

        if (!ModelState.IsValid)
        {
            var invalid = await BuildViewModelAsync(form);
            invalid.Message = "Please correct the highlighted fields.";
            return View("Index", invalid);
        }

        var model = await BuildViewModelAsync(new DepartmentForm());
        try
        {
            await _repository.AddDepartmentAsync(form);
            model.Success = true;
            model.Message = "Dean and department saved successfully.";
            model.Departments = await _repository.GetDepartmentsAsync();
        }
        catch (OracleException ex)
        {
            model.Message = "Oracle rejected the department save. Possible duplicate department/dean or missing schema object: " + ex.Message;
        }
        return View("Index", model);
    }

    private async Task<SetupViewModel> BuildViewModelAsync(DepartmentForm form)
    {
        return new SetupViewModel
        {
            Form = form,
            Departments = await _repository.GetDepartmentsAsync(),
            Users = _repository.GetConfiguredUsers(),
            Designations = _repository.GetDesignations()
        };
    }
}
