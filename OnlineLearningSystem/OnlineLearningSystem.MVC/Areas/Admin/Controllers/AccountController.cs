using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Enums;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
		private readonly IAccountService _service;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IEmailService _emailService; // EmailService əlavə edirik

		// Konstruktor
		public AccountController(IAccountService service,
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			IEmailService emailService) // Konstruktor vasitəsilə EmailService-i daxil edirik
		{
			_service = service;
			_userManager = userManager;
			_signInManager = signInManager;
			_emailService = emailService; // EmailServisi daxil edirik
		}

		// Login səhifəsinə yönləndiririk
		public IActionResult Login()
		{
			if (User.Identity is not null && User.Identity.IsAuthenticated)
				return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

			return View();
		}

		// Login prosesi
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLoginDTO dto, string? returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			try
			{
				await _service.LoginAsync(dto);
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

			return Redirect(returnUrl ?? (User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/"));
		}

		// Qeydiyyat səhifəsi
		public IActionResult Register()
		{
			if (User.Identity is not null && User.Identity.IsAuthenticated)
				return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");

			return View();
		}

		// Qeydiyyat prosesi
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserRegisterDTO dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			try
			{
				// Qeydiyyatın qeydiyyatını gerçəkləşdiririk
				await _service.RegisterAsync(dto);

				// Qeydiyyatdan sonra email göndəririk
				var confirmUrl = Url.Action("ConfirmEmail", "Account", new { email = dto.Email }, Request.Scheme);
				 _emailService.SendEmailConfirm(dto.Email, confirmUrl); // Email göndəririk

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

			return Redirect("/admin/account/login");
		}

		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
			{
				return BadRequest("Invalid email confirmation request.");
			}

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			if (user.EmailConfirmed)
			{
				return RedirectToAction("Login");
			}

			var result = await _userManager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				return RedirectToAction("Login");
			}

			return BadRequest("Email confirmation failed. Please check your confirmation link.");
		}

		// Logout
		public async Task<IActionResult> Logout()
		{
			try
			{
				await _service.LogoutAsync();
				return Redirect("/");
			}
			catch (Exception)
			{
				return BadRequest("Something went wrong!");
			}
		}
	}
}
