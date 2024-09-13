using AutoMapper;
using restful_api.APIs.DTOs;
using restful_api.Core.Entities;
using restful_api.Core.Services.Interfaces;
using restful_api.Infrastructure.Repositories.Interfaces;

namespace restful_api.Core.Services
{
    /// <summary>
    /// Provides implementation for product-related operations.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="IProductRepository"/> for accessing product data.</param>
        /// <param name="mapper">The <see cref="IMapper"/> for mapping between entities and DTOs.</param>
        /// <param name="logger">The <see cref="ILogger{ProductService}"/> for logging.</param>
        public ProductService(IProductRepository repository, IMapper mapper, ILogger<ProductService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a result of a collection of <see cref="ProductDTO"/>.</returns>
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            try
            {
                var products = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all products.");
                throw; // rethrowing exception to be handled by the controller
            }
        }
        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task representing the asynchronous operation, with a result of a <see cref="ProductDTO"/> if found; otherwise, <c>null</c>.</returns>
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return null;
                }
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the product with ID {ProductId}.", id);
                throw;
            }
        }
        /// <summary>
        /// Asynchronously creates a new product.
        /// </summary>
        /// <param name="productDto">The <see cref="ProductDTO"/> containing the product details to be created.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the created <see cref="ProductDTO"/>.</returns>
        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _repository.AddAsync(product);
                if (!await _repository.SaveChangesAsync())
                {
                    _logger.LogError("Failed to save the new product.");
                    throw new Exception("Failed to save the product.");
                }
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new product.");
                throw;
            }
        }
        /// <summary>
        /// Asynchronously updates an existing product.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be updated.</param>
        /// <param name="productDto">The <see cref="ProductDTO"/> containing the updated product details.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the update was successful.</returns>
        public async Task<bool> UpdateProductAsync(int id, ProductDTO productDto)
        {
            try
            {
                var existingProduct = await _repository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return false;
                }
                _mapper.Map(productDto, existingProduct);
                _repository.Update(existingProduct);
                if (!await _repository.SaveChangesAsync())
                {
                    _logger.LogError("Failed to update the product with ID {ProductId}.", id);
                    throw new Exception("Failed to update the product.");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the product with ID {ProductId}.", id);
                throw;
            }
        }
        /// <summary>
        /// Asynchronously deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be deleted.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the deletion was successful.</returns>
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return false;
                }
                _repository.Delete(product);
                if (!await _repository.SaveChangesAsync())
                {
                    _logger.LogError("Failed to delete the product with ID {ProductId}.", id);
                    throw new Exception("Failed to delete the product.");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product with ID {ProductId}.", id);
                throw;
            }
        }
    }
}
