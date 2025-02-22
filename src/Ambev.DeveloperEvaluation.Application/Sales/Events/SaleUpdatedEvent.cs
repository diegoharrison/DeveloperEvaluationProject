namespace Ambev.DeveloperEvaluation.Application.Sales.Events
{
    public class SaleUpdatedEvent
    {
        public Guid SaleId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
