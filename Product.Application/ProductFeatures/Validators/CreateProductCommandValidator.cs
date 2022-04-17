using FluentValidation;
using Product.Application.ProductFeatures.Commands;

namespace Product.Application.ProductFeatures.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name can't be empty");
        }
    }
}
