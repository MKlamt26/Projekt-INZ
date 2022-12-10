using KlalorieOnline.Models.Dtos;
using ProjektINZ.Services.Contracts;
using System.Net.Http.Json;

namespace ProjektINZ.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserDto> GetUser(string UserName)
        {

            try
            {
                var response = await httpClient.GetAsync($"api/User/{UserName}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDto);

                    }
                    return await response.Content.ReadFromJsonAsync<UserDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
            
        }

       
    }
}
