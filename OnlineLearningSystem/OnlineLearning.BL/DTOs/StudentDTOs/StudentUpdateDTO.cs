using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.Core.Enums;

public class StudentUpdateDTO
{
    public int Id { get; set; } // Mövcud tələbəni tapmaq üçün lazımdır
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Grade Grade { get; set; }
    public Gender? Gender { get; set; }
    public IFormFile? Image { get; set; }
    public string ImgUrl { get; set; }
    public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
}

