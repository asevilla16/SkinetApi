using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Infrastructure.Data;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;

namespace Skinet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var list = await _productRepository.GetAllProductsAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var list = await _productRepository.GetAllBrandsAsync();
            return Ok(list);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            var list = await _productRepository.GetAllTypesAsync();
            return Ok(list);
        }
    }
}
