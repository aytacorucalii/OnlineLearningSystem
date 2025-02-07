using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Student : BaseAuditable
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public DateTime EnrollmentDate { get; set; } 
	public string? ImgUrl { get; set; }
	public Gender? Gender { get; set; }
	public string Grade { get; set; }
	public ICollection<Course> EnrolledCourses { get; set; }

	//discount
	//enrollment tarixi arasdir
}