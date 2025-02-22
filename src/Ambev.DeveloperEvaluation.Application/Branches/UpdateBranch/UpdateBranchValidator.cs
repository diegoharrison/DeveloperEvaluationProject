using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

/// <summary>
/// Validator for UpdateBranchCommand
/// </summary>
public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
{
    /// <summary>
    /// Initializes validation rules for UpdateBranchCommand
    /// </summary>
    public UpdateBranchValidator()
    {
        RuleFor(branch => branch.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");

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