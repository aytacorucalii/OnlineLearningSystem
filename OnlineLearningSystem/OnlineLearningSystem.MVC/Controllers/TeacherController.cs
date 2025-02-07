using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningSystem.MVC.Controllers;

public class TeacherController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
