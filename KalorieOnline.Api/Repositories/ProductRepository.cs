using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.shopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public Task<IEnumerable<ProductCategory>> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopOnlineDbContext.Products.ToListAsync();
            return products;
        }
    }
}
