using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class CourseService: ICourseService
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
    public async Task<Course> GetByIdAsync(int id) => await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Course> GetByIdWithChildrenAsync(int id) => await _readRepo.GetByIdAsync(id, "Student") ?? throw new BaseException();

    public async Task<CourseUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<CourseUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<CourseListItemDTO>> GetCourseListItemsAsync() => _mapper.Map<ICollection<CourseListItemDTO>>(await _readRepo.GetAllAsync());

    public async Task<ICollection<CourseViewItemDTO>> GetCourseViewItemsAsync() => _mapper.Map<ICollection<CourseViewItemDTO>>(await _readRepo.GetAllAsync("EnolledStudents"));
    public async Task CreateAsync(CourseCreateDTO dto)
    {
        Course Course = _mapper.Map<Course>(dto);
        Course.ImgUrl = await dto.Image.SaveAsync("Course");
        await _writeRepo.CreateAsync(Course);
    }

    public async Task UpdateAsync(CourseUpdateDTO dto)
    {

        Course oldCourse = await GetByIdAsync(dto.Id);
        Course Course = _mapper.Map<Course>(dto);
        Course.CreatedAt = oldCourse.CreatedAt;
        Course.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("Course") : oldCourse.ImgUrl;
        _writeRepo.Update(Course);
    }

    public async Task DeleteAsync(int id)
    {
        Course Course = await GetByIdWithChildrenAsync(id);

        if (Course.EnrolledStudents.Count != 0) throw new BaseException("This Course has courses!");

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "Course", Course.ImgUrl));
        _writeRepo.Delete(Course);
    }

    public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}
