using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Validator for CreateCustomerCommand
/// </summary>
public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Initializes validation rules for CreateCustomerCommand
    /// </summary>
    public CreateCustomerValidator()
    {
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