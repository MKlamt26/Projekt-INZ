using Microsoft.AspNetCore.Components;
using ProjektKalorie.Services.Contracts;
using ShopOnline.Models.Dtos;

namespace ProjektKalorie.Pages
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IProductService productService { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products = await productService.GetItems();
        }
    }
}
