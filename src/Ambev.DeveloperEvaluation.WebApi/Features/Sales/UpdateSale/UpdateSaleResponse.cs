using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for CreateSale operation
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale date
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The customer identifier
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The branch identifier
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// The sale items
    /// </summary>
    public List<CreateSaleItemResponse> Items { get; set; }
}