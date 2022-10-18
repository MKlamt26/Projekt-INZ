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

        
        public string SearchTerm { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products = await productService.GetItems();
        }

        protected IOrderedEnumerable<IGrouping<int,ProductDto>>GetGrupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int,ProductDto>grupedProductDtos)
        {
            return grupedProductDtos.FirstOrDefault(pg => pg.CategoryId == grupedProductDtos.Key).CategoryName;
        }

        
    }
}
