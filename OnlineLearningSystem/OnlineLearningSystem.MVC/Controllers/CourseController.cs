using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningSystem.MVC.Controllers;

public class CourseController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
