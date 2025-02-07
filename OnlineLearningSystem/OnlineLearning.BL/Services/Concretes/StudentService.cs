using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class StudentService: IStudentService
{
    readonly IStudentReadRepository _readRepo;
    readonly IStudentWriteRepository _writeRepo;
    readonly IMapper _mapper;

    public StudentService(IMapper mapper, IStudentWriteRepository writeRepo, IStudentReadRepository readRepo)
    {
        _mapper = mapper;
        _writeRepo = writeRepo;
        _readRepo = readRepo;
    }
    public async Task<Student> GetByIdAsync(int id) => await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Student> GetByIdWithChildrenAsync(int id) => await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<StudentUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<StudentUpdateDTO>(await GetByIdAsync(id));

    public async Task<ICollection<StudentListItemDTO>> GetStudentListItemsAsync() => _mapper.Map<ICollection<StudentListItemDTO>>(await _readRepo.GetAllAsync());

    public async Task<ICollection<StudentViewItemDTO>> GetStudentViewItemsAsync() => _mapper.Map<ICollection<StudentViewItemDTO>>(await _readRepo.GetAllAsync("Courses"));
    public async Task CreateAsync(StudentCreateDTO dto)
    {
        Student Student = _mapper.Map<Student>(dto);
        Student.ImgUrl = await dto.Image.SaveAsync("Student");
        await _writeRepo.CreateAsync(Student);
    }

    public async Task UpdateAsync(StudentUpdateDTO dto)
    {

        Student oldStudent = await GetByIdAsync(dto.Id);
        Student Student = _mapper.Map<Student>(dto);
        Student.CreatedAt = oldStudent.CreatedAt;
        Student.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("Student") : oldStudent.ImgUrl;
        _writeRepo.Update(Student);
    }

    public async Task DeleteAsync(int id)
    {
        Student Student = await GetByIdWithChildrenAsync(id);

        if (Student.EnrolledCourses.Count != 0) throw new BaseException("This Student has Students!");

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "Student", Student.ImgUrl));
        _writeRepo.Delete(Student);
    }

    public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}
