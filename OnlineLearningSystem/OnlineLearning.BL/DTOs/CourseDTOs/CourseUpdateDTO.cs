using Microsoft.AspNetCore.Http;

namespace OnlineLearning.BL.DTOs;

public class CourseUpdateDTO
{
	public int Id {  get; set; }
	public string CourseName { get; set; }
	public string Description { get; set; }
	public IFormFile Image { get; set; }
	public string ImgUrl { get; set; }
	public decimal Price { get; set; } // Kursun qiyməti
	public string Duration { get; set; }
}
