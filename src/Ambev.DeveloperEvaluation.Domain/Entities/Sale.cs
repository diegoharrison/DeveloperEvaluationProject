using Ambev.DeveloperEvaluation.Domain.Common;
using System.Security.Principal;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the date of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer associated with the sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the branch where the sale was made.
        /// </summary>
        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }

        /// <summary>
        /// Gets or sets the list of items in the sale.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();

        /// <summary>
        /// Gets or sets whether the sale is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }        
    }    
}