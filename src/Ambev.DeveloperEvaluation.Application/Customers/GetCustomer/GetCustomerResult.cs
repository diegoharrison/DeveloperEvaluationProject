namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Response model for GetCustomer operation
/// </summary>
public class GetCustomerResult
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