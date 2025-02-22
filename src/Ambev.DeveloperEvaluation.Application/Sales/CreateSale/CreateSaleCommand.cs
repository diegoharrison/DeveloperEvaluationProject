using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public record CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<CreateSaleItemCommand> Items { get; set; } = new List<CreateSaleItemCommand>();
        public bool IsCancelled { get; set; }
    }

    public record CreateSaleItemCommand
    {
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        /// <summary>
        /// The total amount of the item (calculated as Quantity * UnitPrice - Discount).
        /// </summary>
        public decimal CalculateTotalItemAmount() => (Quantity * UnitPrice) - Discount;
    }
}
