using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IContactService
{
    Task CreateAsync(ContactDTO dto);
    Task<ICollection<ContactDTO>> GetStudentListItemsAsync();
    void SendMessage(ContactDTO message);
}