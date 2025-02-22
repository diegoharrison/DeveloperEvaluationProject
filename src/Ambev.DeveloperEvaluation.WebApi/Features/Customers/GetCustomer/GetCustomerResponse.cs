namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// API response model for GetCustomer operation
/// </summary>
public class GetCustomerResponse
{
    /// <summary>
    /// The unique identifier of the customer
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