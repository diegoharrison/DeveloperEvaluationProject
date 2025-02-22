namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

/// <summary>
/// Result model for UpdateCustomer operation
/// </summary>
public class UpdateCustomerResult
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