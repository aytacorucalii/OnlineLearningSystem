namespace ListRace.PL.ViewModels;

public class HomeVM
{
    public ICollection<TeacherViewItemDTO> Teachers { get; set; }
    public ICollection<CourseViewItemDTO> Courses { get; set; }
}
