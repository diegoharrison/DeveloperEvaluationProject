using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

/// <summary>
/// Validator for CreateBranchRequest
/// </summary>
public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    /// <summary>
    /// Initializes validation rules for CreateBranchRequest
    /// </summary>
    public CreateBranchRequestValidator()
    {
        RuleFor(branch => branch.Name)
            .NotEmpty()
            .WithMessage("Branch name is required")
            .MaximumLength(100)
            .WithMessage("Branch name must not exceed 100 characters");

        RuleFor(branch => branch.Address)
            .NotEmpty()
            .WithMessage("Branch address is required")
            .MaximumLength(200)
            .WithMessage("Branch address must not exceed 200 characters");
    }
}