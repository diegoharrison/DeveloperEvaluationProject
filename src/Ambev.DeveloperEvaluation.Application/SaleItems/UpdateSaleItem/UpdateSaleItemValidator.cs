using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

/// <summary>
/// Validator for UpdateSaleItemCommand
/// </summary>
public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for UpdateSaleItemCommand
    /// </summary>
    public UpdateSaleItemValidator()
    {
        RuleFor(saleItem => saleItem.Id)
            .NotEmpty()
            .WithMessage("SaleItem ID is required");

        RuleFor(saleItem => saleItem.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");

        RuleFor(saleItem => saleItem.ProductDescription)
            .NotEmpty()
            .WithMessage("Product description is required")
            .MaximumLength(200)
            .WithMessage("Product description must not exceed 200 characters");

        RuleFor(saleItem => saleItem.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

        RuleFor(saleItem => saleItem.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Unit price must be greater than 0");

        RuleFor(saleItem => saleItem.Discount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discount must be greater than or equal to 0");
    }
}