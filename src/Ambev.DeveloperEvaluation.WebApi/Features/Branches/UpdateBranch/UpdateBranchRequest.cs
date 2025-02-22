namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;

/// <summary>
/// Represents a request to update a branch in the system.
/// </summary>
public class UpdateBranchRequest
{
    /// <summary>
    /// Gets or sets the branch identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the branch.
    /// </summary>
    public string Address { get; set; }
}