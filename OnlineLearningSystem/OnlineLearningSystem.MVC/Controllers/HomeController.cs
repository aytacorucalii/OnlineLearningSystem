using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningSystem.MVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
