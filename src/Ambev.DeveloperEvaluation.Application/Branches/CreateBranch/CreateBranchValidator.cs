using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

/// <summary>
/// Validator for CreateBranchCommand
/// </summary>
public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
{
    /// <summary>
    /// Initializes validation rules for CreateBranchCommand
    /// </summary>
    public CreateBranchValidator()
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