using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

public class CourseCreateDTO
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } // Kursun qiyməti
    public string Duration { get; set; } // Müddət
    public IFormFile Image { get; set; } // Şəkil

    // Yeni müəllimi təyin etmək üçün
    public int TeacherId { get; set; }

    // Şəkil yükləndikdən sonra URL-i saxlamaq üçün
    public string ImgUrl { get; set; }
    // Seçilmiş kursların ID-ləri
    public List<int> CourseIds { get; set; } = new List<int>();
}
