using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class StatisticsController : Controller
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    public async Task<IActionResult> Index()
    {
		try
		{
			StatisticsDTO statistics = await _statisticsService.GetStatisticsAsync();
			return View(statistics);
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
	}
}
