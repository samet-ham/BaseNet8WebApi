using FluentValidation;
using Core.Entities.Dtos;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterUserValidation : AbstractValidator<UserForRegisterDto>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Mail).NotEmpty().MinimumLength(3).MaximumLength(50).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
