using FluentValidation;
using MovieStoreApi.Service.Models;
namespace MovieStoreApi.Validators.v1
{
    public class UserRegisterModelValidator: AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .MinimumLength(1)
             .WithMessage("User name must be at least 1 character long");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("User password can not be empty");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("User mail address not valid");
        }
    }
}
