namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// API response model for CreateCustomer operation
/// </summary>
public class CreateCustomerResponse
{
    /// <summary>
    /// The unique identifier of the created customer
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