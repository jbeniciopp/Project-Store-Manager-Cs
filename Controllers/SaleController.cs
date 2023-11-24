using Microsoft.AspNetCore.Mvc;
using StoreManagerCs.Models;
using StoreManagerCs.Repository;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SaleController : Controller
    {
        private readonly ISaleRepository _repositorySale;
        private readonly ISaleProductsRepository _repositorySaleProducts;
        private readonly IProductRepository _repositoryProducts;
        public SaleController(ISaleRepository repositorySale, ISaleProductsRepository repositorySaleProducts, IProductRepository repositoryProducts)
        {
            _repositorySale = repositorySale;
            _repositorySaleProducts = repositorySaleProducts;
            _repositoryProducts = repositoryProducts;
        }

        [HttpPost]
        public IActionResult AddSale([FromBody] List<CreateSaleDto> product)
        {
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].ProductId == null)
                {
                    return BadRequest(new { message = "\"productId\" is required" });
                }
                if (product[i].Quantity == null)
                {
                    return BadRequest(new { message = "\"quantity\" is required" });
                }
                if (product[i].Quantity <= 0)
                {
                    return UnprocessableEntity(new { message = "\"quantity\" must be greater than or equal to 1" });
                }

                var cadrastedProduct = _repositoryProducts.GetProductById(product[i].ProductId);
                
                if (cadrastedProduct == null)
                {
                    return NotFound(new { message = "Product not found" });
                }
            }

            var sale = _repositorySale.AddSale();

            ResponseSaleDto response = new()
            {
                SaleId = sale.SaleId,
                ItemsSold = new List<CreateSaleDto>()
            };

            for (int i = 0; i < product.Count; i++)
            {
                var cadrastedProduct = _repositoryProducts.GetProductById(product[i].ProductId);

                Product saleProduct = new()
                {
                    ProductId = cadrastedProduct.ProductId,
                    Name = cadrastedProduct.Name
                };

                _repositorySaleProducts.AddSaleProducts(sale, saleProduct, product[i].Quantity);

                CreateSaleDto createSaleDto = new()
                {
                    ProductId = product[i].ProductId,
                    Quantity = product[i].Quantity
                };

                response.ItemsSold.Add(createSaleDto);
            }

            return Created("", response);
        }
    }
}