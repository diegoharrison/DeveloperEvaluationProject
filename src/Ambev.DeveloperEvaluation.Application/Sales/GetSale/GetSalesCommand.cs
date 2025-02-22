using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale by its ID
/// </summary>
public record GetSalesCommand : IRequest<GetSaleResult>
{
    /// <summary>
    ///    /// Initializes a new instance of GetSaleCommand
    ///       /// </summary>
    public GetSalesCommand()
    {

    }
}