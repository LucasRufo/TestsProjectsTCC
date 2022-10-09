using FluentValidation;

namespace TCC.Alunos.Validators;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(100).WithMessage("{PropertyName} cannot be greater than 100 characters");

        RuleFor(m => m.Age)
            .GreaterThan(18).WithMessage("{PropertyName} cannot be less than 18")
            .LessThan(80).WithMessage("{PropertyName} cannot be greater than 80");

        RuleFor(m => m.Classes)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        RuleForEach(m => m.Classes)
            .NotEmpty().WithMessage("{PropertyName} {CollectionIndex} cannot be empty")
            .MaximumLength(100).WithMessage("{PropertyName} {CollectionIndex} cannot be greater than 100 characters");
    }
}
