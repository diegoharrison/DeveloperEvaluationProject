namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleCancelledEvent
    {
        public Guid SaleId { get; set; }
        public DateTime CancelledAt { get; set; }
    }
}
