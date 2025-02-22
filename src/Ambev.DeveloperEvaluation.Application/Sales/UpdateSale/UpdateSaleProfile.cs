using AutoMapper;
using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, UpdateSaleCommand>();
            CreateMap<UpdateSaleItemResult, UpdateSaleItemResult>();
        }
    }
}
