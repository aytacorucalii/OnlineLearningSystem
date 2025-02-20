using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class ContactService : IContactService
{
    readonly IMapper _mapper;
    readonly IContactReadRepository _readRepo;
    readonly IContactWriteRepository _writeRepo;

    public ContactService(IContactWriteRepository writeRepo, IContactReadRepository readRepo, IMapper mapper)
    {
        _writeRepo = writeRepo;
        _readRepo = readRepo;
        _mapper = mapper;
    }

    public async Task CreateAsync(ContactDTO dto)
    {
        Contact contact = _mapper.Map<Contact>(dto);
        await _writeRepo.CreateAsync(contact);
    }

    public async Task<ICollection<ContactDTO>> GetStudentListItemsAsync() =>
        _mapper.Map<ICollection<ContactDTO>>(await _readRepo.GetAllAsync());

    public void SendMessage(ContactDTO messageDTO)
    {
        Contact message = _mapper.Map<Contact>(messageDTO);
        if (string.IsNullOrWhiteSpace(message.FullName) || string.IsNullOrWhiteSpace(message.Email))
        {
            throw new ArgumentException("Ad və Email boş ola bilməz!");
        }

        _writeRepo.CreateAsync(message);
    }
}