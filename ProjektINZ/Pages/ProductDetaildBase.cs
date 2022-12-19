using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ProjektINZ.Services.Contracts;
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
        [Inject]
        public IDayCartService DayCartService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ISyncLocalStorageService synclocalStorage { get; set; }
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

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                cartItemToAddDto.CartId = @synclocalStorage.GetItem<int>("cartID");
                var cartItemDto=await DayCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
