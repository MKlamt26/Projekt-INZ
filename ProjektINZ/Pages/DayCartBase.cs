using Blazored.LocalStorage;
using KlalorieOnline.Models.Dtos;
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
        public ISyncLocalStorageService synclocalStorage { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalCalories { get; set; }
        protected int TotalQuantity { get; set; }
        protected CartDto CartDto {get; set;}
        protected CartToAddDto cartToAddDto { get; set;}
        public string alertMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                CartDto = await DayCartService.GetCartByUserID(@synclocalStorage.GetItem<int>("userID"));
            }
            catch (Exception ex)
            {
                alertMessage = ex.Message;
                
            }
            if (CartDto == null)
            {
                cartToAddDto = new CartToAddDto() { UserId = @synclocalStorage.GetItem<int>("userID") };
           
                await DayCartService.AddCart(cartToAddDto);
            }


            try
            {
                CartDto = await DayCartService.GetCartByUserID(@synclocalStorage.GetItem<int>("userID"));
                await localStorage.SetItemAsync<int>("cartID", CartDto.Id);
                DayCartItems = await DayCartService.GetItems(@synclocalStorage.GetItem<int>("userID"));
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
