namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the date of the sale.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the customer associated with the sale.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the branch where the sale was made.
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// Gets or sets the list of items in the sale.
    /// </summary>
    public List<SaleItemRequest> Items { get; set; } = new List<SaleItemRequest>();
}

/// <summary>
/// Represents an item in the sale.
/// </summary>
public class SaleItemRequest
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