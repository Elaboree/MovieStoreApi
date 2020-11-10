using FluentValidation;
using MovieStoreApi.Service.v1.Query;

namespace MovieStoreApi.Validators.v1
{
    public class AuthenticateQueryValidator : AbstractValidator<AuthenticateQuery>
    {
        public AuthenticateQueryValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("User name can not be empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("User password can not be empty");
        }
    }
}
