using Domain.Models.Products;
using FluentValidation;

namespace Application.Common.ValidationRules.FluentValidation.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEmptyMessage()
                .WithName("Id");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotEmptyMessage()
                .WithName("Name");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotEmptyMessage()
                .WithName("Price");
        }
    }
}
