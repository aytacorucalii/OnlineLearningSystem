using FluentValidation;

namespace OnlineLearning.BL.DTOs;

public class TeacherViewItemDTO
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Subject { get; set; }
	public string ImgUrl { get; set; }
}
