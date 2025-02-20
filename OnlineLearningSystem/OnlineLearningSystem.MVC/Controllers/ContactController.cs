using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;

namespace OnlineLearningSystem.MVC.Controllers;

public class ContactController : Controller
{
	readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
	public IActionResult Index()
	{
		return View();
	}

    [HttpPost]
    public IActionResult SendMessage(ContactDTO model)
    {
        try
        {
            _service.SendMessage(model);
            TempData["SuccessMessage"] = "Mesaj uğurla göndərildi!";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Xəta baş verdi: " + ex.Message;
            return RedirectToAction("Index");
        }

    }
}
