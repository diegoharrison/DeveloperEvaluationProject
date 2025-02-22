namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Represents the response returned after successfully creating a new customer.
/// </summary>
public class CreateCustomerResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created customer.
    /// </summary>
    public Guid Id { get; set; }
}