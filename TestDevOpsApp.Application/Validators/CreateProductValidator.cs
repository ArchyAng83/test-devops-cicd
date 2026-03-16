using FluentValidation;
using TestDevOpsApp.Application.DTOs;

namespace TestDevOpsApp.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Цена должна быть больше нуля!");
        }
    }
}
