namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;

/// <summary>
/// API response model for UpdateBranch operation
/// </summary>
public class UpdateBranchResponse
{
    /// <summary>
    /// The unique identifier of the updated branch
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the branch
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The address of the branch
    /// </summary>
    public string Address { get; set; }
}