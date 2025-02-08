using Microsoft.AspNetCore.Http;
using OnlineLearning.Core.Enums;

public class StudentUpdateDTO
{
    public int StudentId { get; set; } // Mövcud tələbəni tapmaq üçün lazımdır
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Grade { get; set; }
    public Gender? Gender { get; set; }
    public IFormFile? Image { get; set; }
    public string ImgUrl { get; set; }
    public List<int> CourseIds { get; set; } = new List<int>();
}

