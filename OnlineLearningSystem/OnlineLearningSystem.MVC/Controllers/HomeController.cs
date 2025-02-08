using ListRace.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearningSystem.MVC.Controllers;
public class HomeController : Controller
{
    readonly ITeacherService _teacherService;
	readonly ICourseService _courseService;

    public HomeController(ICourseService courseService, ITeacherService teacherService)
    {
        _courseService = courseService;
        _teacherService = teacherService;
    }

    public async Task<IActionResult> Index()
	{
            HomeVM VM = new()
            {
                Teachers = await _teacherService.GetTeacherViewItemsAsync(),
                Courses = await _courseService.GetCourseViewItemsAsync()
            };

            return View(VM);
     
    }
}
