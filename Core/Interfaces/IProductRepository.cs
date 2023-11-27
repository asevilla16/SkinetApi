using Skinet.Core.Entities;


namespace Skinet.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetAllBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetAllTypesAsync();
    }
}
