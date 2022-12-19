using Blazored.LocalStorage;
using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProjektINZ.Services.Contracts;
using ProjektINZ.ViewModels;

namespace ProjektINZ.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }


        public NavigationManager NavigationManager { get; set; }
        
        

        public AuthenticationStateProvider AuthStateProvider { get; set; }


        public UserDto userDataDto { get; set; }
        
        public string ErrorMessage { get; set; }
        public UserModel userModel = new UserModel();


        public async void HandleLogin()
        {
            //
            try
            {
                var userDataDto = await UserService.GetUser(userModel.Name);
               
                if (userDataDto != null)
                {
                    Console.WriteLine("Loged me in");
                    await localStorage.SetItemAsync<string>("username", "michal");
                    await AuthStateProvider.GetAuthenticationStateAsync();
                    
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    OnInitializedAsync();
                }

                

            }
            catch (Exception)
            {

                throw;
            }
          


           
        }


      

        protected override Task OnInitializedAsync()
        {
            userModel = new UserModel();
            return base.OnInitializedAsync();

        }
    }
}
