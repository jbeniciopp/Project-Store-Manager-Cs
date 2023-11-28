using Microsoft.AspNetCore.Mvc;
using StoreManagerCs.Models;
using StoreManagerCs.Repository;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpGet("{ProductId}")]
        public IActionResult GetProductById(int ProductId)
        {
            var request = _repository.GetProductById(ProductId);

            ProductDto response = new()
            {
                ProductId = request.ProductId,
                Name = request.Name
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (product.Name == null)
            {
                return BadRequest(new { message = "\"name\" is required" });
            }
            if (product.Name.Length < 5)
            {
                return UnprocessableEntity(new { message = "\"name\" length must be at least 5 characters long" });
            }

            return Created("", _repository.AddProduct(product));
        }

        [HttpPut]
        public IActionResult PutProduct([FromBody] Product product)
        {
            return Ok(_repository.UpdateProduct(product));
        }

        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            try
            {
                _repository.DeleteProduct(ProductId);
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}