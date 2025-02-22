namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The name of the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// The name of the branch where the sale was made.
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Indicates whether the sale is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The list of items in the sale.
        /// </summary>
        public List<SaleItemResult> Items { get; set; } = new List<SaleItemResult>();
    }

    /// <summary>
    /// Represents an item in the sale.
    /// </summary>
    public class SaleItemResult
    {
        /// <summary>
        /// The unique identifier of the sale item.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the product associated with the item.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// The quantity of the item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the item.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to the item.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total amount of the item (calculated as Quantity * UnitPrice - Discount).
        /// </summary>
        public decimal TotalItemAmount => CalculateTotalItemAmount();

        /// <summary>
        /// Method to calculate the total amount of the item.
        /// </summary>
        public decimal CalculateTotalItemAmount()
        {
            return (Quantity * UnitPrice) - Discount;
        }
    }
}
