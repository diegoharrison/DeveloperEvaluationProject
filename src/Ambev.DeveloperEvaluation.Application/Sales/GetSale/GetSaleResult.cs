namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date of the sale
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The identifier of the customer associated with the sale
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// The total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The identifier of the branch where the sale was made
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// The list of items in the sale
    /// </summary>
    public List<SaleItemResult> Items { get; set; } = new List<SaleItemResult>();

    /// <summary>
    /// Indicates whether the sale is cancelled
    /// </summary>
    public bool IsCancelled { get; set; }
}

/// <summary>
/// Represents an item in the sale
/// </summary>
public class SaleItemResult
{
    /// <summary>
    /// The unique identifier of the sale item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the product
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The price of the product
    /// </summary>
    public decimal Price { get; set; }
}