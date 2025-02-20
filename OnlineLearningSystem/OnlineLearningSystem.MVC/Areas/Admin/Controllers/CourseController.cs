using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
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
        IEnumerable<CourseListItemDTO> list = await _service.GetCourseListItemsAsync();

        return View(list);
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            return View(dto);
        }

        try
        {
            await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {

            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            return View(await _service.GetByIdForUpdateAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CourseUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            return View(dto);
        }

        try
        {
            await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Teachers"] = new SelectList(await _teacherService.GetTeacherListItemsAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            await _service.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _service.GetByIdWithChildrenAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
}
