namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleItemCancelledEvent
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime CancelledAt { get; set; }
    }
}
