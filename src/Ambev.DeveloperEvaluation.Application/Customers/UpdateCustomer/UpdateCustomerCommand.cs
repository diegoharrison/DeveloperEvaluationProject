using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

/// <summary>
/// Command for updating a customer
/// </summary>
public record UpdateCustomerCommand : IRequest<UpdateCustomerResult>
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

    public UpdateCustomerCommand(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}