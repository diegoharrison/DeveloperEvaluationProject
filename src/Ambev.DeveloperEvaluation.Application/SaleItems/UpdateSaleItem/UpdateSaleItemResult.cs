namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

/// <summary>
/// Result model for UpdateSaleItem operation
/// </summary>
public class UpdateSaleItemResult
{
    /// <summary>
    /// The unique identifier of the updated sale item
    /// </summary>
    public Guid Id { get; set; }

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

    /// <summary>
    /// The total amount of the item
    /// </summary>
    public decimal TotalItemAmount { get; set; }
}