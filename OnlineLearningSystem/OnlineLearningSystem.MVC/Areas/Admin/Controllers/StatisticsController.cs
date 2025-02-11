using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;

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
			HomeVM VM = new()
			{
				Statistics = new List<StatisticsDTO> { await _statisticsService.GetStatisticsAsync() }
			};

			return View(VM);
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
	}
}
