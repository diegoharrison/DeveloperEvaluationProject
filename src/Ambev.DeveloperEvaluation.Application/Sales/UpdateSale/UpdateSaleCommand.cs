using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for updating a sale
/// </summary>
public record UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    /// <summary>
    /// The unique identifier of the sale to update
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date of the sale
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The identifier of the customer associated with the sale
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The identifier of the branch where the sale was made
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// The list of items in the sale
    /// </summary>
    public List<SaleItemCommand> Items { get; set; } = new List<SaleItemCommand>();
}

/// <summary>
/// Represents an item in the sale
/// </summary>
public class SaleItemCommand
{
    /// <summary>
    /// The identifier of the product associated with the item
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// The description of the product
    /// </summary>
    public string ProductDescription { get; set; }

    /// <summary>
    /// The quantity of the item
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the item
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The discount applied to the item
    /// </summary>
    public decimal Discount { get; set; }
}