namespace OnlineLearning.BL.DTOs;

public class CourseViewItemDTO
{
	public string CourseName { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; } // Kursun qiyməti
	public string Duration { get; set; }
	public string ImgUrl { get; set; }
}