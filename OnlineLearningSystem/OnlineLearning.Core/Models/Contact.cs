using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Contact: BaseEntity
{
	public string? UserName { get; set; }
	public string? Comment { get; set; }
	public double Rating { get; set; }
	public int? CourseId { get; set; }
	public Course? Course { get; set; }
}
