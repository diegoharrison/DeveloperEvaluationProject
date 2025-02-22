namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// Request model for updating a customer
/// </summary>
public class UpdateCustomerRequest
{
    /// <summary>
    /// The unique identifier of the customer to update
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The new name of the customer
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The new email of the customer
    /// </summary>
    public string Email { get; set; }
}