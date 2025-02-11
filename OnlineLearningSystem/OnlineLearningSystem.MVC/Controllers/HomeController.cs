
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Controllers;
public class HomeController : Controller
{
    readonly ITeacherService _teacherService;
	readonly ICourseService _courseService;
    readonly IStatisticsService _statisticsService;

	public HomeController(ICourseService courseService, ITeacherService teacherService, IStatisticsService statisticsService)
	{
		_courseService = courseService;
		_teacherService = teacherService;
		_statisticsService = statisticsService;
	}

	public async Task<IActionResult> Index()
	{
        try
        {
			HomeVM VM = new()
			{
				Statistics = new List<StatisticsDTO> { await _statisticsService.GetStatisticsAsync() },
				Teachers = await _teacherService.GetTeacherViewItemsAsync(),
				Courses = await _courseService.GetCourseViewItemsAsync()
			};


			return View(VM);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
     
    }
}
