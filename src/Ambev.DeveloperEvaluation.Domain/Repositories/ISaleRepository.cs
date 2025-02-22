using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Defines the contract for the sale repository.
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Gets a sale by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the sale.</param>
        /// <returns>The sale.</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all sales.
        /// </summary>
        /// <returns>A list of sales.</returns>
        Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new sale to the repository.
        /// </summary>
        /// <param name="sale">The sale to add.</param>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing sale in the repository.
        /// </summary>
        /// <param name="sale">The sale to update.</param>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the sale to delete.</param>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}