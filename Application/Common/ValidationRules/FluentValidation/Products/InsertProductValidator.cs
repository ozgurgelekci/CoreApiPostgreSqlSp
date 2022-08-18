using Domain.Models.Products;
using FluentValidation;

namespace Application.Common.ValidationRules.FluentValidation.Products
{
    public class InsertProductValidator : AbstractValidator<InsertProductModel>
    {
        public InsertProductValidator()
        {
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
