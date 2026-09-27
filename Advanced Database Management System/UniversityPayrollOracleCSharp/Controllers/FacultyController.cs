using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class FacultyController : AppController
{
    private readonly PayrollRepository _repository;

    public FacultyController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (!IsLoggedIn) return LoginRedirect();
        var model = new FacultyListViewModel { Faculty = await _repository.GetFacultyListAsync() };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin", "Payroll Staff")) return AccessDenied();
        return View(await BuildAddViewModelAsync(new FacultyForm()));
    }

    [HttpPost]
    public async Task<IActionResult> Add([Bind(Prefix = "Form")] FacultyForm form)
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin", "Payroll Staff")) return AccessDenied();

        if (!ModelState.IsValid)
        {
            var invalid = await BuildAddViewModelAsync(form);
            invalid.Message = "Please correct the highlighted fields.";
            return View(invalid);
        }

        var model = await BuildAddViewModelAsync(new FacultyForm());
        try
        {
            await _repository.AddFacultyAsync(form);
            model.Success = true;
            model.Message = "Faculty saved successfully.";
        }
        catch (OracleException ex)
        {
            model.Message = "Oracle rejected the faculty save. Possible duplicate email or missing department: " + ex.Message;
        }
        return View(model);
    }

    private async Task<AddFacultyViewModel> BuildAddViewModelAsync(FacultyForm form)
    {
        return new AddFacultyViewModel
        {
            Form = form,
            Departments = await _repository.GetDepartmentsAsync(),
            Designations = _repository.GetDesignations()
        };
    }
}
