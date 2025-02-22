using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;

/// <summary>
/// Command for updating a branch
/// </summary>
public record UpdateBranchCommand : IRequest<UpdateBranchResult>
{
    /// <summary>
    /// The unique identifier of the branch to update
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// The new name of the branch
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The new address of the branch
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Initializes a new instance of UpdateBranchCommand
    /// </summary>
    /// <param name="id">The ID of the branch to update</param>
    /// <param name="name">The new name of the branch</param>
    /// <param name="address">The new address of the branch</param>
    public UpdateBranchCommand(Guid id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
}