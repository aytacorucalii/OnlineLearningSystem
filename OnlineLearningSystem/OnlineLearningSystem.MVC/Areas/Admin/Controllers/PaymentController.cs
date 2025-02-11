﻿using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using AutoMapper;
using OnlineLearning.Core.Models;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Enums;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PaymentController : Controller
	{
		private readonly IPaymentService _paymentService;
		private readonly IMapper _mapper;

		public PaymentController(IPaymentService paymentService, IMapper mapper)
		{
			_paymentService = paymentService;
			_mapper = mapper;
		}

		// Ödənişlərin siyahısını göstərmək
		public async Task<IActionResult> Index()
		{
			try
			{
				var payments = await _paymentService.GetAllPaymentsAsync();
				var paymentDtos = _mapper.Map<List<PaymentDTO>>(payments); // AutoMapper ilə DTO-ya çeviririk
				return View(paymentDtos);
			}
			catch (Exception ex)
			{
				// Loglama əlavə edə bilərsiniz
				TempData["Error"] = $"Ödənişlər alınarkən xəta baş verdi: {ex.Message}";
				return View("Error");
			}
		}

		// Ödənişin detallarını göstərmək
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var payment = await _paymentService.GetPaymentByIdAsync(id);
				if (payment == null)
				{
					TempData["Error"] = "Ödəniş tapılmadı.";
					return RedirectToAction(nameof(Index));
				}

				var paymentDto = _mapper.Map<PaymentDTO>(payment);
				return View(paymentDto);
			}
			catch (Exception ex)
			{
				TempData["Error"] = $"Ödənişin detalları alınarkən xəta baş verdi: {ex.Message}";
				return RedirectToAction(nameof(Index));
			}
		}

		// Ödənişin statusunu dəyişmək
		[HttpPost]
		public async Task<IActionResult> UpdateStatus(int id, bool status)
		{
			try
			{
				var payment = await _paymentService.GetPaymentByIdAsync(id);
				if (payment == null)
				{
					TempData["Error"] = "Ödəniş tapılmadı.";
					return RedirectToAction(nameof(Index));
				}

				// Parametreyi doğru şekilde geçiriyoruz
				await _paymentService.UpdatePaymentStatusAsync(id, status);

				TempData["Success"] = "Ödənişin statusu uğurla yeniləndi.";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["Error"] = $"Ödənişin statusu yenilənərkən xəta baş verdi: {ex.Message}";
				return RedirectToAction(nameof(Index));
			}
		}
        [HttpPost]
        public async Task<IActionResult> StartPayment([FromBody] PaymentDTO paymentDto)
        {
            var result = await _paymentService.ProcessPaymentAsync(paymentDto);

            if (result)
            {
                return Json(new { success = true, status = paymentDto.Status.ToString() });
            }

            return Json(new { success = false, message = "Ödəniş uğursuz oldu." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Json(payments);
        }
    }
}
