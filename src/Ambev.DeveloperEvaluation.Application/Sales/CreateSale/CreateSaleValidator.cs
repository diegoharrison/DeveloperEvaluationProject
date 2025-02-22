using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale date is required");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required");
            RuleFor(x => x.BranchId).NotEmpty().WithMessage("Branch ID is required");
            RuleFor(x => x.Items).NotEmpty().WithMessage("Sale items are required");
            RuleForEach(x => x.Items).ChildRules(items =>
            {
                items.RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required");
                items.RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero");
                items.RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero");
            });
        }
    }
}
