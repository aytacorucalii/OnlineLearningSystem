using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.ContactValidations;

public class ContactDTOValidator : AbstractValidator<ContactDTO>
{
    public ContactDTOValidator()
    {
        RuleFor(e => e.FullName)
           .NotEmpty().WithMessage("FullName cannot be empty!")
           .MinimumLength(2).WithMessage("FullName must be at least 2 symbols long!")
           .MaximumLength(100).WithMessage("The length of the Full name cannot exceed 100 symbols!");
        RuleFor(e => e.Email)
           .NotEmpty().WithMessage("Email cannot be empty!")
           .EmailAddress().WithMessage("Email address is wrong!");

        RuleFor(e => e.Subject)
           .NotEmpty().WithMessage("Subject cannot be empty!")
           .MinimumLength(2).WithMessage("Subject must be at least 2 symbols long!")
           .MaximumLength(200).WithMessage("The length of the Subject cannot exceed 200 symbols!");

        RuleFor(e => e.Message)
           .NotEmpty().WithMessage("Subject cannot be empty!")
           .MinimumLength(2).WithMessage("Subject must be at least 2 symbols long!")
           .MaximumLength(1000).WithMessage("The length of the Subject cannot exceed 1000 symbols!");
        RuleFor(e => e.Phone)
           .NotEmpty().WithMessage("Phone number cannot be empty!")
           .Matches(@"^\+994\((70|10|50|51|55|71|77|99)\)\d{3}-\d{2}-\d{2}$")
           .WithMessage("Invalid phone number format! Example: +994(xx)xxx-xx-xx");

    }
}