namespace OnlineLearning.BL.DTOs;

public class ContactDTO
{
	public int Id { get; set; }
    public string Name { get; set; }
    public string? UserId { get; set; }
	public string? UserName { get; set; }
	public string? Comment { get; set; }
	public string? UserRole { get; set; }
	public double Rating { get; set; }
	public int CourseId { get; set; }
}
