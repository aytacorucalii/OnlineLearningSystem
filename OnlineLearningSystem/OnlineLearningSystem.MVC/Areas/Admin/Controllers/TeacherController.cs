using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.DAL;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _service;
        private readonly ICourseService _courseService;

        // Constructor-da kurs servisini daxil edirik
        public TeacherController(ITeacherService service, ICourseService courseService)
        {
            _service = service;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TeacherListItemDTO> list = await _service.GetTeacherListItemsAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            // Kursları ViewData ilə göndəririk
            var courses = await _courseService.GetCourseListItemsAsync();
            ViewBag.Courses = courses?.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CourseName,
            }) ?? new List<SelectListItem>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Əgər form qeyri-düzgün doldurulubsa, kursları yenidən göndəririk
                var courses = await _courseService.GetCourseListItemsAsync();
                ViewBag.Courses = new SelectList(courses, "Id", "Name",dto.CourseId); // Düzgün şəkildə ViewBag istifadə edilir
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
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
                ModelState.AddModelError("CustomError", "Something went wrong!");
                return View(dto);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                // Kursları ViewData ilə göndəririk
                var courses = await _courseService.GetCourseListItemsAsync();
                ViewBag.Courses = new SelectList(courses, "Id", "Name"); // Düzgün şəkildə ViewBag istifadə edilir

                return View(await _service.GetByIdForUpdateAsync(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
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
        public async Task<IActionResult> Update(TeacherUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Əgər form qeyri-düzgün doldurulubsa, kursları yenidən göndəririk
                var courses = await _courseService.GetCourseListItemsAsync();
                ViewBag.Courses = new SelectList(courses, "Id", "Name", dto.CourseId); // Düzgün şəkildə ViewBag istifadə edilir
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
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception)
            {
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
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
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
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
    }
}
