using restful_api.APIs.DTOs;

namespace restful_api.Core.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for product-related operations.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of a collection of <see cref="ProductDTO"/>.</returns>
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task representing the asynchronous operation, with a result of a <see cref="ProductDTO"/> if found; otherwise, <c>null</c>.</returns>
        Task<ProductDTO> GetProductByIdAsync(int id);

        /// <summary>
        /// Asynchronously creates a new product.
        /// </summary>
        /// <param name="productDto">The <see cref="ProductDTO"/> containing the product details to be created.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the created <see cref="ProductDTO"/>.</returns>
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);

        /// <summary>
        /// Asynchronously updates an existing product.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be updated.</param>
        /// <param name="productDto">The <see cref="ProductDTO"/> containing the updated product details.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the update was successful.</returns>
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);

        /// <summary>
        /// Asynchronously deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be deleted.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the deletion was successful.</returns>
        Task<bool> DeleteProductAsync(int id);
    }
}
