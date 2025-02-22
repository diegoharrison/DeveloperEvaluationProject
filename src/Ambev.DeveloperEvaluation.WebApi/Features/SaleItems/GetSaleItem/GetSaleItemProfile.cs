using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// Profile for mapping GetSaleItem feature requests to commands
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItem feature
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<Guid, Application.SaleItems.GetSaleItem.GetSaleItemCommand>()
            .ConstructUsing(id => new Application.SaleItems.GetSaleItem.GetSaleItemCommand(id));
    }
}