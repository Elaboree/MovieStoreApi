using FluentValidation;
using MovieStoreApi.Service.v1.Command;

namespace MovieStoreApi.Validators.v1
{
    public class AddMovieCriticCommandValidator : AbstractValidator<AddMovieCriticCommand>
    {
        public AddMovieCriticCommandValidator()
        {
            RuleFor(x => x.Comment)
                .NotNull()
                .MinimumLength(5)
                .WithMessage("The movie comment must be at least 5 character long");
            RuleFor(x => x.Rating)
                .InclusiveBetween(1,10).
                WithMessage("The movie rating must be at 1-10");
            RuleFor(x => x.MovieId)
                .NotNull()
                .WithMessage("The movie id can not be empty");
        }
    }
}
