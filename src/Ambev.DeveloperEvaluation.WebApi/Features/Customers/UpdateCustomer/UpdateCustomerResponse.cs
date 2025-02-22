namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// API response model for UpdateCustomer operation
/// </summary>
public class UpdateCustomerResponse
{
    /// <summary>
    /// The unique identifier of the updated customer
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the customer
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The email of the customer
    /// </summary>
    public string Email { get; set; }
}