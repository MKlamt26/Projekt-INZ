

using ShopOnline.Models.Dtos;

namespace ProjektKalorie.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<IEnumerable<ProductDto>> SearchProducts(string SearchTerm);
        Task<ProductDto> GetItem(int id);
    }
}
