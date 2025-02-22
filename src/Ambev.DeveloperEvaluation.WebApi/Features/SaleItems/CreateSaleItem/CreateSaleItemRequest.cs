namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Represents a request to create a new sale item in the system.
/// </summary>
public class CreateSaleItemRequest
{
    /// <summary>
    /// Gets or sets the identifier of the product associated with the item.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string ProductDescription { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the item.
    /// </summary>
    public decimal Discount { get; set; }
}