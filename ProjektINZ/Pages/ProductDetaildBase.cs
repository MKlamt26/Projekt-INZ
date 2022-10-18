using Microsoft.AspNetCore.Components;
using ProjektKalorie.Services.Contracts;
using ShopOnline.Models.Dtos;

namespace ProjektINZ.Pages
{
    public class ProductDetaildBase:ComponentBase
    {

        [Parameter]
        public int Id { get; set; } 

        [Inject]
        public IProductService ProductService { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync() // tu się dzieeje akcja
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }


    }
}
