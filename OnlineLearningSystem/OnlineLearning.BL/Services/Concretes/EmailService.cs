
using Microsoft.Extensions.Configuration;
using OnlineLearning.BL.Services.Abstractions;
using System.Net;
using System.Net.Mail;

namespace OnlineLearning.BL.Services.Concretes;

public class EmailService : IEmailService
{
	private readonly IConfiguration _configuration;

	// SMTP parametrlərini toplamaq üçün helper metodu əlavə edirik
	private SmtpClient GetSmtpClient()
	{
		var smtpClient = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]))
		{
			EnableSsl = true,
			Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"])
		};
		return smtpClient;
	}

	public EmailService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	// Ümumi email göndərmə metodu
	private void SendEmail(string toUser, string subject, string body, bool isHtml = false)
	{
		try
		{
			var smtpClient = GetSmtpClient();
			var from = new MailAddress(_configuration["Email:Sender"]);
			var to = new MailAddress(toUser);
			var message = new MailMessage(from, to)
			{
				Subject = subject,
				Body = body,
				IsBodyHtml = isHtml
			};
			smtpClient.Send(message);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Email göndərmə xətası: {ex.Message}");
		}
	}

	// Sadə email göndərmək
	public void SendEmail(string toUser)
	{
		string body = "Welcome to Our Page";
		SendEmail(toUser, "Hello from Online Learning System", body);
	}

	// Təsdiq emaili göndərmək
	public void SendEmailConfirm(string toUser, string confirmUrl)
	{
		string body = $"<a href='{confirmUrl}'>Click here to confirm your email</a>";
		SendEmail(toUser, "Confirm Email", body, true);
	}
}
