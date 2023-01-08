using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CaloriesOnlineDbContext caloriesOnlineDbContext;

        public ProductRepository(CaloriesOnlineDbContext caloriesOnlineDbContext)
        {
            this.caloriesOnlineDbContext = caloriesOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.caloriesOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await caloriesOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product =await caloriesOnlineDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.caloriesOnlineDbContext.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchProducts(string SearchTerm)
        {
            var products = await this.caloriesOnlineDbContext.Products.Where(pr => pr.Name.ToLower().Contains(SearchTerm.ToLower())).ToListAsync();
            return products;
        }

       

       
    }
}
