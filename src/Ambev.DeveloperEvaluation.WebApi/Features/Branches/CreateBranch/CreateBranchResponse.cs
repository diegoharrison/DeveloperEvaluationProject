namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

/// <summary>
/// API response model for CreateBranch operation
/// </summary>
public class CreateBranchResponse
{
    /// <summary>
    /// The unique identifier of the created branch
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