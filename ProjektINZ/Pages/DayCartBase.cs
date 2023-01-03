using Blazored.LocalStorage;
using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Components;
using ProjektINZ.Services.Contracts;
using ProjektINZ.ViewModels;
using ProjektINZ.ViewModels.Calculator;
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
        [Inject]
        public IUserDataService UserDataService { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalCalories { get; set; }   
        protected int TotalQuantity { get; set; }
        protected CartDto CartDto {get; set;}
        protected CartToAddDto cartToAddDto { get; set;}
        protected EatedDaily eatedDaily { get; set; }
        protected DailyBilans dailyBilans { get; set; }
        protected CalculateCalories calculateCalories { get; set; }
        public string alertMessage { get; set; }
        protected DateTime SelectedDate { get; set; }
        protected IEnumerable<CartDto> userCartsDtos { get; set; }
        protected DateTime selectedDate=DateTime.Now;
        protected DateTime minDate = new DateTime(2020, 1, 1);
        protected DateTime maxDate = new DateTime(2022, 12, 31);




        protected override async Task OnInitializedAsync()
        {
            try
            {
                userCartsDtos =await DayCartService.GetUserCarts(@synclocalStorage.GetItem<int>("userID"));
                //CartDto = await DayCartService.GetCartByUserID(@synclocalStorage.GetItem<int>("userID"));
                eatedDaily = new EatedDaily();
                dailyBilans = new DailyBilans();
                CartDto = userCartsDtos.SingleOrDefault(uc => uc.CreatedDate.Date == DateTime.Now.Date);
                if(CartDto != null)
                {
                    await localStorage.SetItemAsync<int>("cartID", CartDto.Id);
                    DayCartItems = await DayCartService.GetItems(@synclocalStorage.GetItem<int>("userID"));
                    SetDailyEated();
                    await Calculate();
                    SetDailyBilans();
                }
                else
                {
                    cartToAddDto = new CartToAddDto() { UserId = @synclocalStorage.GetItem<int>("userID"), CreatedDate = DateTime.Now };


                    await DayCartService.AddCart(cartToAddDto);
                    await OnInitializedAsync();
                }
             
            }
            catch (Exception ex)
            {
                alertMessage = ex.Message;
                
            }
            if (userCartsDtos == null)
            {
                cartToAddDto = new CartToAddDto() { UserId = @synclocalStorage.GetItem<int>("userID"),CreatedDate=DateTime.Now };
                
           
                await DayCartService.AddCart(cartToAddDto);
            }
          


            //try
            //{
            //    eatedDaily = new EatedDaily();
            //    dailyBilans = new DailyBilans();
            //    CartDto = await DayCartService.GetCartByUserID(@synclocalStorage.GetItem<int>("userID"));
            //    await localStorage.SetItemAsync<int>("cartID", CartDto.Id);
            //    DayCartItems = await DayCartService.GetItems(@synclocalStorage.GetItem<int>("userID"));
            //    SetDailyEated();
            //    await Calculate();
            //    SetDailyBilans();



            //}
            //catch (Exception ex)
            //{
                

            //    ErrorMessage = ex.Message;
            //}
        }

        protected async Task Calculate()
        {
            try
            {
                calculateCalories = await UserDataService.Calculate(synclocalStorage.GetItem<int>("userID"));
                if(calculateCalories==null)
                {
                    calculateCalories = new CalculateCalories();
                    
                }

            }
            catch (Exception ex)
            {
                calculateCalories = new CalculateCalories();

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


                   
                    await OnInitializedAsync();
                    


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

     
        private CartItemDto GetCartItem(int id)
        {
            return DayCartItems.FirstOrDefault(i => i.Id == id);
        }

     

        private void SetDailyEated()
        {

            eatedDaily.DailyEatedKcal = Math.Round(this.DayCartItems.Sum(p => p.TotalCalories),1);
            eatedDaily.DailyEatedCarbo = Math.Round(this.DayCartItems.Sum(s => s.TotalCarbo),1);
            eatedDaily.DailyEatedProtein= Math.Round(this.DayCartItems.Sum(s=>s.TotalProtein),1);
            eatedDaily.DailyEatedFat= Math.Round(this.DayCartItems.Sum(s=>s.TotalFat),1);
            
            



        }

        private void SetDailyBilans()
        {

            
            dailyBilans.DailyBilansKcal = eatedDaily.DailyEatedKcal - calculateCalories.DailyRequirementKcal;



        }


        private void SetTotalQantity()
        {
            TotalQuantity =this.DayCartItems.Sum(s=>s.Qty);
        }

       
        

       


    }
}
