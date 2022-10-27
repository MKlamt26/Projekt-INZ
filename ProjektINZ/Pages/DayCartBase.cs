using Microsoft.AspNetCore.Components;
using ProjektINZ.Services.Contracts;
using ShopOnline.Models.Dtos;

namespace ProjektINZ.Pages
{
    public class DayCartBase:ComponentBase
    {
        [Inject]
        public IDayCartService DayCartService { get; set; }
        [Inject]
        public IEnumerable<CartItemDto> DayCartItems { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                DayCartItems = await DayCartService.GetItems(HardCoded.UserId);
                
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
