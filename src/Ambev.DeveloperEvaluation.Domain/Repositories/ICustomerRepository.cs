using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for the customer repository.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets a sale by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the sale.</param>
        /// <returns>The sale.</returns>
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all sales.
        /// </summary>
        /// <returns>A list of sales.</returns>
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new sale to the repository.
        /// </summary>
        /// <param name="sale">The sale to add.</param>
        Task<Customer> CreateAsync(Customer sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing sale in the repository.
        /// </summary>
        /// <param name="sale">The sale to update.</param>
        Task<Customer> UpdateAsync(Customer sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the sale to delete.</param>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}