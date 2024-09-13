using restful_api.Core.Entities;

namespace restful_api.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Defines the contract for product data access operations.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of a collection of <see cref="Product"/> entities.</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the <see cref="Product"/> entity if found; otherwise, <c>null</c>.</returns>
        Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously adds a new product to the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(Product product);

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be updated.</param>
        void Update(Product product);

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be deleted.</param>
        void Delete(Product product);

        /// <summary>
        /// Asynchronously saves all changes made to the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the save operation was successful.</returns>
        Task<bool> SaveChangesAsync();
    }
}
