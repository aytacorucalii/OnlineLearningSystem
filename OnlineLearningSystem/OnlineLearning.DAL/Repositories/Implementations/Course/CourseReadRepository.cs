using ListRace.DL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
{
    readonly AppDbContext _context;
	public CourseReadRepository(AppDbContext context) : base(context)
	{
        _context = context;
	}
    public IQueryable<Course> GetCourses()
    {
        return _context.Courses.AsNoTracking();
    }
}
