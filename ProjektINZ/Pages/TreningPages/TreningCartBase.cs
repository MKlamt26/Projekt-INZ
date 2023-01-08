using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Components;
using ProjektINZ.Services.Contracts;
using Blazored.LocalStorage;
using KlalorieOnline.Models.Dtos.TreningDtos;

namespace ProjektINZ.Pages.TreningPages
{
    public class TreningCartBase : ComponentBase
    {
        [Inject]
        public ITreningCartService treningCartService { get; set; }
        [Inject]
        public IEnumerable<TreningCartItemDto> treningCartItemDtos { get; set; }
        [Inject]
        public ISyncLocalStorageService synclocalStorage { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        [Inject]
        public IUserDataService userDataService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string errorMessage { get; set; }


        protected TreningCartDto treningCartDto { get; set; }
        protected TreningCartToAddDto treningCartToAddDto { get; set; }

        protected TreningCartItemDto selectedExercise { get; set; }
        public string alertMessage { get; set; }
        public int SelectedexerciseId { get; set; }

        protected IEnumerable<TreningCartDto> userTreningCartsDto { get; set; }
        protected DateTime selectedDate { get; set; }
        protected DateTime minDate = new DateTime(2020, 1, 1);
        protected DateTime maxDate = new DateTime(2022, 12, 31);

        protected override async Task OnInitializedAsync()
        {

            try
            {

                userTreningCartsDto = await treningCartService.GetUserTreningCarts(@synclocalStorage.GetItem<int>("userID"));
                selectedDate = @synclocalStorage.GetItem<DateTime>("dataTime");
                if (selectedDate == DateTime.MinValue)
                {
                    selectedDate = DateTime.Now;
                }

                treningCartDto = userTreningCartsDto.SingleOrDefault(uc => uc.CreatedDate.Date == selectedDate.Date);


            }
            catch (Exception ex)
            {
                alertMessage = ex.Message;

            }
            if (treningCartDto != null)
            {
                await localStorage.SetItemAsync<int>("cartID", treningCartDto.Id);
                treningCartItemDtos = await treningCartService.GetExercises(@synclocalStorage.GetItem<int>("cartID"));

            }
            else
            {
                treningCartToAddDto = new TreningCartToAddDto() { UserId = @synclocalStorage.GetItem<int>("userID"), CreatedDate = selectedDate };


                await treningCartService.AddTreningCart(treningCartToAddDto);
                await OnInitializedAsync();
            }
            if (userTreningCartsDto == null)
            {
                treningCartToAddDto = new TreningCartToAddDto() { UserId = @synclocalStorage.GetItem<int>("userID"), CreatedDate = selectedDate };


                await treningCartService.AddTreningCart(treningCartToAddDto);
            }




        }



        protected async Task ShowDayCartClick(DateTime dateTime)
        {
            try
            {
                //selectedDate = dateTime;
                await localStorage.SetItemAsync<DateTime>("dataTime", dateTime);


                await OnInitializedAsync();



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task EditSelectedExercie_Click(TreningCartItemDto exercise)
        {
            selectedExercise= exercise;
            OnInitializedAsync();


            //navigationManager.NavigateTo("/EditExercise");
        }

        protected async Task EditExercise_Click(TreningCartItemDto exercise)
        {
            selectedExercise = exercise;
            OnInitializedAsync();


           
        }


        protected async Task UpdateTreningCart_Click(int id, int weight, int sets, int repetitions)
        {
            try
            {
                if (sets > 0 && repetitions > 0)
                {
                    var updateItemDto = new TreningCartUpdateDto
                    {
                        TreningCartItemId = id,
                        Wight= weight,
                        Sets = sets,
                        Repetitions = repetitions

                    };

                    await this.treningCartService.UpdateTreningCart(updateItemDto);

                    selectedExercise =null;

                    await OnInitializedAsync();



                }
                else
                {
                    var item = this.treningCartItemDtos.FirstOrDefault(i => i.Id == id);

                    if (item != null)
                    {
                        item.Sets = 1;
                        item.Repetitions = 1;

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected async Task DeleteTreningCartItem_Click(int id)
        {
            var cartItemDto = await treningCartService.DeleteItem(id);

            await OnInitializedAsync();



        }



    }
}

