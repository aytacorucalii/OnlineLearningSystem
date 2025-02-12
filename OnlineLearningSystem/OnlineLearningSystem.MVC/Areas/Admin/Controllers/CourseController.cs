using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class CourseController : Controller
{
    readonly ICourseService _service;
    readonly ITeacherService _teacherService;

    public CourseController(ICourseService service, ITeacherService teacherService)
    {
        _service = service;
        _teacherService = teacherService;
    }

    public async Task<IActionResult> Index()
    {
        return await HandleServiceCall(async () => View(await _service.GetCourseListItemsAsync()));
    }

    public async Task<IActionResult> Create()
    {
        var teachers = await _teacherService.GetTeacherListItemsAsync();
        ViewBag.Teachers = teachers.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Name // və ya hansısa bir başqa xüsusiyyət
        }) ?? new List<SelectListItem>();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            var teachers = await _teacherService.GetTeacherListItemsAsync();
            ViewBag.Teachers = teachers.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name // və ya hansısa bir başqa xüsusiyyət
            }) ?? new List<SelectListItem>();

            // Error mesajı
            ViewData["ErrorMessage"] = "Kursu yaratmaq mümkün olmadı. Xahiş edirik məlumatları yoxlayın.";
            return View(dto);
        }

        return await HandleServiceCall(async () =>
        {
            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }, dto);
    }

    public async Task<IActionResult> Update(int id)
    {
        var teachers = await _teacherService.GetTeacherListItemsAsync();
        ViewBag.Teachers = teachers.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Name // və ya hansısa bir başqa xüsusiyyət
        }) ?? new List<SelectListItem>();

        return await HandleServiceCall(async () => View(await _service.GetByIdForUpdateAsync(id)));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CourseUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            // Teacher siyahısını yenidən göndəririk, əgər səhv varsa
            var teachers = await _teacherService.GetTeacherListItemsAsync();
            ViewBag.Teachers = teachers.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name // və ya hansısa bir başqa xüsusiyyət
            }) ?? new List<SelectListItem>(); // Null yoxlaması

            // Error mesajı
            ViewData["ErrorMessage"] = "Kursu yeniləmək mümkün olmadı. Xahiş edirik məlumatları yoxlayın.";
            return View(dto);
        }

        return await HandleServiceCall(async () =>
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }, dto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        return await HandleServiceCall(async () =>
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        });
    }

    public async Task<IActionResult> Details(int id)
    {
        return await HandleServiceCall(async () => View(await _service.GetByIdWithChildrenAsync(id)));
    }

    private async Task<IActionResult> HandleServiceCall(Func<Task<IActionResult>> action, object? dto = null)
    {
        try
        {
            return await action();
        }
        catch (BaseException ex)
        {
            // Əgər dto varsa, səhv mesajını əlavə et
            if (dto != null) ModelState.AddModelError("CustomError", ex.Message);
            return dto == null ? BadRequest(ex.Message) : View(dto);
        }
        catch (Exception ex)
        {
            // Ümumi səhv mesajı
            if (dto != null) ModelState.AddModelError("CustomError", "Something went wrong!");
            return dto == null ? BadRequest("Something went wrong!") : View(dto);
        }
    }
}
