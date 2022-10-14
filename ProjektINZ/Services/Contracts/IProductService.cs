

using ShopOnline.Models.Dtos;

namespace ProjektKalorie.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
