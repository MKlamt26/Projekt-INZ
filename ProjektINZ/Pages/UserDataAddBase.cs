using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ProjektINZ.Services.Contracts;
using ProjektINZ.ViewModels.Calculator;
using System.Linq;

namespace ProjektINZ.Pages
{
    public class UserDataAddBase : ComponentBase
    {

        

        [Inject]
        public IUserDataService UserDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        
        public CalculateCalories CalculateCalories { get; set; }
        public UserDataDto userDataDto { get; set; }
        public IEnumerable<UserDataDto> userDataDtos { get; set; }
        public string ErrorMessage { get; set; }

        protected async Task AddUserData_Click(UserDataDto userdataDto)
        {
            try
            {
                
                var cartItemDto = await UserDataService.AddUserData(userdataDto);
                
                //NavigationManager.NavigateTo("/userData");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //CalculateCalories = await UserDataService.Calculate(HardCoded.UserDataID);

                userDataDtos = await UserDataService.GetUserDatas(HardCoded.UserId);
                userDataDto = userDataDtos.Last();
                
                //userDataDto = await UserDataService.GetUserData(HardCoded.UserDataID);

                //var cartItemDto = await UserDataService.AddUserData(userDataDto);


            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task Calculate()
        {
            try
            {
                CalculateCalories = await UserDataService.Calculate(HardCoded.UserDataID);





            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }



        private async void OnSubmitMethod(UserDataDto userdataDto)
        {


            var cartItemDto = await UserDataService.AddUserData(userdataDto);




        }
    }
}
