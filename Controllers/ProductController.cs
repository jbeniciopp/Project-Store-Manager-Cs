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
            return Ok(_repository.GetProductById(ProductId));
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
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