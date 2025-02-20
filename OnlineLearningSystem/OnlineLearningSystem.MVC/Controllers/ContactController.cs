using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Core.Models;

namespace OnlineLearningSystem.MVC.Controllers;

public class ContactController : Controller
{
	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Submit(ContactFormModel model)
	{
		if (ModelState.IsValid)
		{
			// Burada məlumatları database-ə yazmaq və ya email göndərmək olar
			ViewBag.Message = "Mesajınız uğurla göndərildi!";
			return View("Index", model);
		}

		return View("Index");
	}
}
