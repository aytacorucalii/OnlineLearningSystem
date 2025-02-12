using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineLearning.BL.DTOs;

public class TeacherCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public int ExperienceYears { get; set; }
    public decimal Salary { get; set; }
    public int CourseId { get; set; }
    public IFormFile? Image { get; set; } // Şəkil optional olaraq təyin edilib
    public string ImgUrl { get; set; }

    public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
}
