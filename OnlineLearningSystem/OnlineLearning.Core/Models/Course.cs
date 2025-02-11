using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Course : BaseAuditable
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string ImgUrl { get; set; }
    public string Duration { get; set; } // Kurs müddəti (məsələn: "12 Weeks")

    // Hər kursun bir müəllimi olur (One-to-Many əlaqə)
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    // Many-to-Many əlaqəsi
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

