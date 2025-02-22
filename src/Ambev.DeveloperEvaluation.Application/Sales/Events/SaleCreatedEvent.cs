namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleCreatedEvent
    {
        public Guid SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
