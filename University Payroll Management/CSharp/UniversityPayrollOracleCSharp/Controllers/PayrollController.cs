using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class PayrollController : AppController
{
    private readonly PayrollRepository _repository;

    public PayrollController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin", "Payroll Staff")) return AccessDenied();
        return View(await BuildViewModelAsync(new PayrollForm()));
    }

    [HttpPost]
    public async Task<IActionResult> Index([Bind(Prefix = "Form")] PayrollForm form)
    {
        if (!IsLoggedIn) return LoginRedirect();
        if (!RoleAllowed("Admin", "Payroll Staff")) return AccessDenied();

        if (!ModelState.IsValid)
        {
            var invalid = await BuildViewModelAsync(form);
            invalid.Message = "Please correct the highlighted fields.";
            return View(invalid);
        }

        var model = await BuildViewModelAsync(new PayrollForm());
        try
        {
            await _repository.AddPayrollTransactionAsync(form);
            model.Success = true;
            model.Message = "Payroll transaction saved successfully.";
        }
        catch (OracleException ex)
        {
            model.Message = "Oracle rejected the payroll transaction. Check faculty, staff, finance officer IDs and salary values: " + ex.Message;
        }
        return View(model);
    }

    private async Task<PayrollEntryViewModel> BuildViewModelAsync(PayrollForm form)
    {
        return new PayrollEntryViewModel
        {
            Form = form,
            Faculty = await _repository.GetActiveFacultyListAsync(),
            PayrollStaff = await _repository.GetPayrollStaffListAsync(),
            FinanceOfficers = await _repository.GetFinanceOfficerListAsync()
        };
    }
}
