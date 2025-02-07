using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.DTOs;

public class TeacherListItemDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Subject { get; set; } // Fənn
	public int ExperienceYears { get; set; }
	public ICollection<Course> Courses { get; set; }
}
