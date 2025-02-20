using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    readonly IContactService _service;

    public DashboardController(IContactService service)
    {
        _service = service;
    }
    public IActionResult Index()
	{
		return View();
	}
    public async Task<IActionResult> Messages()
    {
        var messages = await _service.GetStudentListItemsAsync();
        return View(messages);
    }
}
