using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Controllers;

public class CourseController : Controller
{
	readonly ITeacherService _teacherService;
	readonly ICourseService _courseService;
	public CourseController(ITeacherService teacherService, ICourseService courseService)
	{
		_teacherService = teacherService;
		_courseService = courseService;
	}
	public async Task<IActionResult> Index()
	{
		try
		{
			HomeVM VM = new()
			{
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
    [HttpGet]
    public async Task<IActionResult> SearchCourses(string searchTerm, int page = 1, int pageSize = 10)
    {
        if (page < 1 || pageSize < 1)
        {
            return BadRequest("Səhifə dəyəri düzgün deyil");
        }

        var courses = await _courseService.SearchCoursesAsync(searchTerm, page, pageSize);

        //if (courses == null || !courses.Any())
        //{
        //    return NotFound("Axtarış nəticəsi tapılmadı");
        //}

        return Ok(courses);
    }

}
