using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;

namespace OnlineLearningSystem.MVC.Controllers;

public class ContactController : Controller
{
	readonly IContactService _service;
    readonly AppDbContext _contexts;
    readonly IMapper _mapper;
    public ContactController(IContactService service, AppDbContext contexts, IMapper mapper)
    {
        _service = service;
        _contexts = contexts;
        _mapper = mapper;
    }

    [HttpGet]
    [HttpGet]
    public IActionResult Index()
    {
        return View(new ContactDTO()); 
    }

    [HttpPost]
    public IActionResult SendMessage(ContactDTO model)
    {
        //try
        //{
            _service.SendMessage(model);
            TempData["SuccessMessage"] = "Mesaj uğurla göndərildi!";
            return RedirectToAction("Index");
        //}
        //catch (Exception ex)
        //{
        //    TempData["ErrorMessage"] = "Xəta baş verdi: " + ex.Message;
        //    return RedirectToAction("Index");
        //}

    }
}
