using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;

namespace Skinet.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(c => c.ProductBrand)
                .Include(c => c.ProductType)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(c => c.ProductBrand)
                .Include(c => c.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        
    }
}
