using Microsoft.AspNetCore.Http;

namespace OnlineLearning.BL.DTOs;

public class CourseCreateDTO
{
	public string CourseName { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; } // Kursun qiyməti
	public string Duration { get; set; }//muddet
	public IFormFile Image	{ get; set; }
}
