using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Utilities;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class TeacherService : ITeacherService
{
	readonly ITeacherWriteRepository _writeRepo;
	readonly ITeacherReadRepository _readRepo;
	readonly IMapper _mapper;
	public TeacherService(ITeacherWriteRepository writeRepo, ITeacherReadRepository readRepo, IMapper mapper)
	{
		_writeRepo = writeRepo;
		_readRepo = readRepo;
		_mapper = mapper;
	}

	public async Task<Teacher> GetByIdAsync(int id) => await _readRepo.GetByIdAsync(id) ?? throw new BaseException();

	public async Task<Teacher> GetByIdWithChildrenAsync(int id) => await _readRepo.GetByIdAsync(id, "Course") ?? throw new BaseException();

	public async Task<TeacherUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<TeacherUpdateDTO>(await GetByIdAsync(id));

	public async Task<ICollection<TeacherListItemDTO>> GetTeacherListItemsAsync() => _mapper.Map<ICollection<TeacherListItemDTO>>(await _readRepo.GetAllAsync());

	public async Task<ICollection<TeacherViewItemDTO>> GetTeacherViewItemsAsync() => _mapper.Map<ICollection<TeacherViewItemDTO>>(await _readRepo.GetAllAsync("Courses"));
	public async Task CreateAsync(TeacherCreateDTO dto)
	{
		Teacher Teacher = _mapper.Map<Teacher>(dto);
        Teacher.ImgUrl = await dto.Image.SaveAsync("teacher");
        await _writeRepo.CreateAsync(Teacher);
	}

	public async Task UpdateAsync(TeacherUpdateDTO dto)
    {

        Teacher oldTeacher = await GetByIdAsync(dto.Id);
		Teacher Teacher = _mapper.Map<Teacher>(dto);
		Teacher.CreatedAt = oldTeacher.CreatedAt;
        Teacher.ImgUrl = dto.Image is not null ? await dto.Image.SaveAsync("teacher") : oldTeacher.ImgUrl;
        _writeRepo.Update(Teacher);
	}

	public async Task DeleteAsync(int id)
	{
		Teacher teacher = await GetByIdWithChildrenAsync(id);

		if (teacher.Courses.Count != 0) throw new BaseException("This Teacher has courses!");

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "teacher", teacher.ImgUrl));
        _writeRepo.Delete(teacher);
	}

	public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}