using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a branch by its ID
/// </summary>
public record GetBranchesCommand : IRequest<GetBranchResult>
{
    /// <summary>
    /// Initializes a new instance of GetSBranchesCommand
    /// </summary>
    public GetBranchesCommand()
    {

    }
}