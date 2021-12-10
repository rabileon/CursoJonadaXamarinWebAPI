

using FluentValidation;

namespace DTOs.Validators;

internal class NewBookValidator : AbstractValidator<NewBookDTO>
{
    public NewBookValidator()
    {
        RuleFor(b => b.Title)
            .NotNull()
            .WithMessage("Debe enviarse un titulo")
            .MinimumLength(5)
            .WithMessage("El titulo debe contener al menos 5 caracteres");

        RuleFor(b => b.Author)
            .NotNull()
            .WithMessage("Debe enviarse un autor")
            .MinimumLength(5)
            .WithMessage("El autor debe contener al menos 5 caracteres");

        RuleFor(b => b.Editorial)
            .NotNull()
            .WithMessage("Debe enviarse una editorial")
            .MinimumLength(5)
            .WithMessage("La editorial debe contener al menos 5 caracteres");

        RuleFor(b => b.Image)
            .NotNull()
            .WithMessage("Debe enviarse una imagen")
            .MinimumLength(20)
            .WithMessage("La imagen debe contener al menos 20 caracteres");
    }
}

