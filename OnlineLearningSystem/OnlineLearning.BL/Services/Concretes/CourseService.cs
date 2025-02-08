using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class CourseService : ICourseService
{
    readonly ICourseReadRepository _readRepo;
    readonly ICourseWriteRepository _writeRepo;
    readonly IMapper _mapper;

    public CourseService(ICourseReadRepository readRepo, ICourseWriteRepository writeRepo, IMapper mapper)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _mapper = mapper;
    }

    public async Task<Course> GetByIdAsync(int id) =>
        await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Course> GetByIdWithChildrenAsync(int id) =>
        await _readRepo.GetByIdAsync(id, "StudentCourses.Student") ?? throw new BaseException();

    public async Task<CourseUpdateDTO> GetByIdForUpdateAsync(int id) =>
        _mapper.Map<CourseUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<CourseListItemDTO>> GetCourseListItemsAsync() =>
        _mapper.Map<ICollection<CourseListItemDTO>>(await _readRepo.GetAllAsync());

    public async Task<ICollection<CourseViewItemDTO>> GetCourseViewItemsAsync() =>
        _mapper.Map<ICollection<CourseViewItemDTO>>(await _readRepo.GetAllAsync("StudentCourses.Student"));

    public async Task CreateAsync(CourseCreateDTO dto)
    {
        Course course = _mapper.Map<Course>(dto);
        course.ImgUrl = await dto.Image.SaveAsync("course");
        await _writeRepo.CreateAsync(course);
    }

    public async Task UpdateAsync(CourseUpdateDTO dto)
    {
        Course oldCourse = await GetByIdAsync(dto.Id);
        Course course = _mapper.Map<Course>(dto);
        course.CreatedAt = oldCourse.CreatedAt;
        course.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("course") : oldCourse.ImgUrl;
        _writeRepo.Update(course);
    }

    public async Task DeleteAsync(int id)
    {
        Course course = await GetByIdWithChildrenAsync(id);

        if (course.StudentCourses.Count != 0)
            throw new BaseException("This course has enrolled students!");

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "course", course.ImgUrl));
        _writeRepo.Delete(course);
    }

    public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}
