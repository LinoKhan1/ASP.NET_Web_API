using Microsoft.EntityFrameworkCore;
using restful_api.Core.Entities;
using restful_api.Infrastructure.Data;
using restful_api.Infrastructure.Repositories.Interfaces;

namespace restful_api.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access operations for <see cref="Product"/> entities.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="ApplicationDbContext"/> instance used for data access.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves all products from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of a collection of <see cref="Product"/> entities.</returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the <see cref="Product"/> entity if found; otherwise, <c>null</c>.</returns>
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Asynchronously adds a new product to the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be updated.</param>
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be deleted.</param>
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        /// <summary>
        /// Asynchronously saves all changes made to the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the save operation was successful.</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
