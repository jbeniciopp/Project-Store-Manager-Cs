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
                if (product[i].ProductId == 0)
                {
                    return BadRequest(new { message = "\"productId\" is required" });
                }
                if (product[i].Quantity == 0)
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

                _repositorySaleProducts.AddSaleProducts(sale, cadrastedProduct, product[i].Quantity);

                CreateSaleDto createSaleDto = new()
                {
                    ProductId = product[i].ProductId,
                    Name = cadrastedProduct.Name,
                    Quantity = product[i].Quantity
                };

                response.ItemsSold.Add(createSaleDto);
            }

            return Created("", response);
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            var sales = _repositorySale.GetSales();

            var response = new List<ResponseSaleDto>();

            for (int i = 0; i < sales.Count; i++)
            {
                ResponseSaleDto sale = new()
                {
                    SaleId = sales[i].SaleId,
                    ItemsSold = new List<CreateSaleDto>()
                };

                var products = _repositorySaleProducts.GetSaleProductsBySaleId(sale.SaleId);

                for (int idx = 0; idx < products.Count; idx++)
                {
                    CreateSaleDto productDto = new()
                    {
                        ProductId = products[idx].Product?.ProductId ?? 0,
                        Name = products[idx].Product?.Name,
                        Quantity = products[idx].Quantity
                    };

                    sale.ItemsSold.Add(productDto);
                }

                response.Add(sale);
            }

            return Ok(response);
        }

        [HttpGet("{SaleId}")]
        public IActionResult GetSaleById(int SaleId)
        {
            var sale = _repositorySale.GetSaleById(SaleId);

            if (sale == null)
            {
                return NotFound();
            }

            ResponseSaleDto response = new()
            {
                SaleId = SaleId,
                ItemsSold = new List<CreateSaleDto>()
            };

            var products = _repositorySaleProducts.GetSaleProductsBySaleId(SaleId);

            for (int idx = 0; idx < products.Count; idx++)
            {
                CreateSaleDto productDto = new()
                {
                    ProductId = products[idx].Product?.ProductId ?? 0,
                    Name = products[idx].Product?.Name,
                    Quantity = products[idx].Quantity
                };

                response.ItemsSold.Add(productDto);
            }

            return Ok(response);
        }

        [HttpDelete("{SaleId}")]
        public IActionResult DeleteSale(int SaleId)
        {
            try
            {
                _repositorySaleProducts.DeleteSales(SaleId);
                _repositorySale.DeleteSale(SaleId);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);

                return BadRequest();
                throw;
            }
        }
    }
}