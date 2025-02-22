using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// Validator for UpdateCustomerRequest
/// </summary>
public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    /// <summary>
    /// Initializes validation rules for UpdateCustomerRequest
    /// </summary>
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");

        RuleFor(customer => customer.Name)
            .NotEmpty()
            .WithMessage("Customer name is required")
            .MaximumLength(100)
            .WithMessage("Customer name must not exceed 100 characters");

        RuleFor(customer => customer.Email)
            .NotEmpty()
            .WithMessage("Customer email is required")
            .EmailAddress()
            .WithMessage("Customer email must be a valid email address");
    }
}