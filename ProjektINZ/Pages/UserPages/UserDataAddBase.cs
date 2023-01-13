using Blazored.LocalStorage;
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
        [Inject]
        public ISyncLocalStorageService localStorage { get; set; }


        public CalculateCalories CalculateCalories { get; set; }
        public UserDataDto userDataDto { get; set; }
        public IEnumerable<UserDataDto> userDataDtos { get; set; }
        public string ErrorMessage { get; set; }

        protected async Task AddUserData_Click(UserDataDto userdataDto)
        {
            try
            {
                userdataDto.UserId = @localStorage.GetItem<int>("userID");

                await UserDataService.AddUserData(userdataDto);
                NavigationManager.NavigateTo("UserDatas");




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
                
                userDataDtos = await UserDataService.GetUserDatas(@localStorage.GetItem<int>("userID"));
                if (userDataDtos.FirstOrDefault()!=null)
                {
                    userDataDto = userDataDtos.Last();
                }
                else
                {
                    userDataDto=new UserDataDto() 
                    { Sex="man",
                    UserId= @localStorage.GetItem<int>("userID"),
                    Age =0,

                    Height=0,
                    Weight=0,
                    Activity="low",
                    Goal="GrowUp",
                    CreatedDate=DateTime.Now,
                    };
                }

               

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
                CalculateCalories = await UserDataService.Calculate(@localStorage.GetItem<int>("userID"));

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }



        protected async Task AddData()
        {

            try
            {
                NavigationManager.NavigateTo("/AddUserData");

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
            




        }
    }
}
