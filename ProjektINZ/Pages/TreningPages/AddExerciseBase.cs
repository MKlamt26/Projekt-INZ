using Microsoft.AspNetCore.Components;
using ProjektINZ.Services.Contracts;
using Blazored.LocalStorage;
using KlalorieOnline.Models.Dtos;
using KlalorieOnline.Models.Dtos.TreningDtos;

namespace ProjektINZ.Pages.TreningPages
{
    public class AddExerciseBase : ComponentBase
    {

        [Inject]
        public IExerciseService exerciseService { get; set; }

        [Inject]
        public ITreningCartService treningCartService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ISyncLocalStorageService localStorage { get; set; }
        [Inject]
        public ISyncLocalStorageService synclocalStorage { get; set; }


        public ExerciseDto exerciseDto { get; set; }
        public IEnumerable<ExerciseDto> exerciseSDtos { get; set; }
        public string ErrorMessage { get; set; }



        protected override async Task OnInitializedAsync()
        {
            try
            {

                exerciseSDtos = await exerciseService.GetExercises();
            

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }


        protected async Task AddToTreningCart_Click(TreningCartItemToAddDto treningCartItemToAddDto)
        {
            try
            {
                treningCartItemToAddDto.TreningCartId = @synclocalStorage.GetItem<int>("cartID");
                var cartItemDto = await treningCartService.AddExercise(treningCartItemToAddDto);
                navigationManager.NavigateTo("/TreningCart");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto = await treningCartService.DeleteItem(id);

            await OnInitializedAsync();



        }



    }
}
