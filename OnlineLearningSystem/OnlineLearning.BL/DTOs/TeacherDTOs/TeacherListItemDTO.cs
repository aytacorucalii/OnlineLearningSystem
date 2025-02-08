public class TeacherListItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public int ExperienceYears { get; set; }
    public List<int> CourseIds { get; set; } // Kurs ID-ləri
}
