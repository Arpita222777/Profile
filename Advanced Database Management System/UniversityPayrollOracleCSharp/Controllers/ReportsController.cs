using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using UniversityPayrollOracleCSharp.Models;
using UniversityPayrollOracleCSharp.Services;

namespace UniversityPayrollOracleCSharp.Controllers;

public sealed class ReportsController : AppController
{
    private readonly PayrollRepository _repository;

    public ReportsController(PayrollRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? month, int? year, string? search)
    {
        if (!IsLoggedIn) return LoginRedirect();
        var model = await BuildReportViewModelAsync(month, year, search);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Export(string? month, int? year, string? search)
    {
        if (!IsLoggedIn) return LoginRedirect();
        var model = await BuildReportViewModelAsync(month, year, search);
        var csv = PayrollRepository.BuildCsv(model.Rows);
        var fileName = $"department_salary_report_{model.Month}_{model.Year}.csv".Replace(' ', '_');
        return File(Encoding.UTF8.GetBytes(csv), "text/csv", fileName);
    }

    private async Task<ReportsViewModel> BuildReportViewModelAsync(string? month, int? year, string? search)
    {
        var now = DateTime.Today;
        var monthNumber = ParseMonth(month) ?? now.Month;
        var reportYear = year.GetValueOrDefault(now.Year);
        var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);
        return new ReportsViewModel
        {
            MonthNumber = monthNumber,
            Month = monthName,
            Year = reportYear,
            Search = search ?? string.Empty,
            Rows = await _repository.GetReportSummaryAsync(monthNumber, reportYear, search)
        };
    }

    private static int? ParseMonth(string? month)
    {
        if (int.TryParse(month, out var number) && number >= 1 && number <= 12)
        {
            return number;
        }

        if (string.IsNullOrWhiteSpace(month))
        {
            return null;
        }

        for (var i = 1; i <= 12; i++)
        {
            var name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            if (string.Equals(name, month, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return null;
    }
}
