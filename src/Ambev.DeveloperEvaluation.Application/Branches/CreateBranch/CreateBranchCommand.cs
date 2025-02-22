using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

/// <summary>
/// Command for creating a new branch
/// </summary>
public record CreateBranchCommand : IRequest<CreateBranchResult>
{
    /// <summary>
    /// The name of the branch
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The address of the branch
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Initializes a new instance of CreateBranchCommand
    /// </summary>
    /// <param name="name">The name of the branch</param>
    /// <param name="address">The address of the branch</param>
    public CreateBranchCommand(string name, string address)
    {
        Name = name;
        Address = address;
    }
}