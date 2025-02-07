using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningSystem.MVC.Controllers;

public class ContactController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
