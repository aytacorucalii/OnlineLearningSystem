using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Course : BaseAuditable
{
	public string CourseName { get; set; }
	public int TeacherId { get; set; }
	public Teacher Teacher { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; } // Kursun qiyməti
	public decimal Rating { get; set; } 
	public int RatingCount { get; set; } // 1-3 ulduz arasında qiymətləndirmə
	public string ImgUrl { get; set; }
	public string Duration { get; set; } // Kurs müddəti (məsələn: "12 Weeks")
	public ICollection<Student> EnrolledStudents { get; set; }

}

