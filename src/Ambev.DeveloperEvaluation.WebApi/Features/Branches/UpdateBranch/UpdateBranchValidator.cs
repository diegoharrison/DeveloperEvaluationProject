using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;

/// <summary>
/// Validator for UpdateBranchRequest
/// </summary>
public class UpdateBranchValidator : AbstractValidator<UpdateBranchRequest>
{
    /// <summary>
    /// Initializes validation rules for UpdateBranchRequest
    /// </summary>
    public UpdateBranchValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(100);
    }
}