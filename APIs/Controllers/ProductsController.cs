using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restful_api.APIs.DTOs;
using restful_api.Core.Services;
using restful_api.Core.Services.Interfaces;

namespace restful_api.APIs.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="service">The product service.</param>
        /// <param name="logger">The logger.</param>
        public ProductController(IProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of all products.</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            try
            {
                var products = await _service.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all products.");
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            try
            {
                var product = await _service.GetProductByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the product with ID {ProductId}.", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="productDto">The product details.</param>
        /// <returns>The created product.</returns>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO productDto)
        {
            try
            {
                var createdProduct = await _service.CreateProductAsync(productDto);
                return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new product.");
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="productDto">The updated product details.</param>
        /// <returns>An action result indicating the outcome of the update.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDto)
        {
            try
            {
                var result = await _service.UpdateProductAsync(id, productDto);
                if (!result)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found for update.", id);
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the product with ID {ProductId}.", id);
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>An action result indicating the outcome of the deletion.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteProductAsync(id);
                if (!result)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found for deletion.", id);
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product with ID {ProductId}.", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
