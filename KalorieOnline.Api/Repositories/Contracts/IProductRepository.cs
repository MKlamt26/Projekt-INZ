using KalorieOnline.Api.Entities;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<IEnumerable<Product>> GetItem(int id);
        Task<IEnumerable<ProductCategory>> GetCategory(int id);
    }
}
