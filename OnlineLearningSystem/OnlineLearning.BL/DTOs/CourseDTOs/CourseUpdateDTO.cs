using Microsoft.AspNetCore.Http;

public class CourseUpdateDTO
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public string ImgUrl { get; set; }
    public decimal Price { get; set; } // Kursun qiyməti
    public string Duration { get; set; }
    public int TeacherId { get; set; } // Müəllim dəyişməsi üçün

                                       // Seçilmiş kursların ID-ləri
    public List<int> CourseIds { get; set; } = new List<int>();
}
