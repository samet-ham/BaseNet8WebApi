using Core.Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginUserValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress()
                                 .NotEmpty();

            RuleFor(x=> x.Password).NotEmpty();
        }
    }
}
