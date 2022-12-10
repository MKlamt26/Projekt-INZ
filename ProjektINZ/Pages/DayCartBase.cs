using Blazored.LocalStorage;
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
        [Inject]
        public ISyncLocalStorageService localStorage { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalCalories { get; set; }
        protected int TotalQuantity { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            try
            {
                DayCartItems = await DayCartService.GetItems(@localStorage.GetItem<int>("userID"));
                CalculateCartSummaryTotals();
                

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto = await DayCartService.DeleteItem(id);
            
            await OnInitializedAsync();
            


        }

        protected async Task UpdateQtyCartItem_Click(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    var updateItemDto = new CartItemQtyUpdateDto
                    {
                        CartItemId = id,
                        Qty = qty
                    };

                    await this.DayCartService.UpdateQty(updateItemDto);


                    //UpdateItemTotalPrice(returnedUpdateItemDto);
                    await OnInitializedAsync();
                    //await UpdateItemTotalPrice(returnedUpdateItemDto);

                    //CartChanged();

                    //await MakeUpdateQtyButtonVisible(id, false);


                }
                else
                {
                    var item = this.DayCartItems.FirstOrDefault(i => i.Id == id);

                    if (item != null)
                    {
                        item.Qty = 1;
                        item.TotalCalories = item.Calories;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        //private async Task UpdateItemTotalPrice(CartItemDto cartItemDto)
        //{
        //    var item = GetCartItem(cartItemDto.Id);

        //    if (item != null)
        //    {
        //        item.TotalCalories = cartItemDto.Calories * cartItemDto.Qty;
        //    }

           

        //}
        private CartItemDto GetCartItem(int id)
        {
            return DayCartItems.FirstOrDefault(i => i.Id == id);
        }

        private void CalculateCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQantity();
        }

        private void SetTotalPrice()
        {

            TotalCalories = this.DayCartItems.Sum(p => p.TotalCalories).ToString()+"Kcl";
            

        }

        private void SetTotalQantity()
        {
            TotalQuantity =this.DayCartItems.Sum(s=>s.Qty);
        }

       
        

       


    }
}
