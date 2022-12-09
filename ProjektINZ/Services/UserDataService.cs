using KlalorieOnline.Models.Dtos;

using ProjektINZ.Services.Contracts;
using ProjektINZ.ViewModels.Calculator;
using System.Net.Http.Json;
using System.Text;

namespace ProjektINZ.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient httpClient;

        public UserDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
       

       

        public  async Task<UserDataDto> GetUserData(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/UserData/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDataDto);

                    }
                    return await response.Content.ReadFromJsonAsync<UserDataDto>();

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

        public async Task<IEnumerable<UserDataDto>> GetUserDatas(int userId)
        {
            
                try
                {
                    var userDataDtos = await this.httpClient.GetFromJsonAsync<IEnumerable<UserDataDto>>("api/UserData");
                    return userDataDtos;
                }
                catch (Exception)
                {

                    throw;
                }
            
        }


        public async Task<UserDataDto> AddUserData(UserDataDto userDataDto)
        {
            try
            {


                var response = await httpClient.PostAsJsonAsync<UserDataDto>("api/UserData", userDataDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDataDto);
                    }

                    return await response.Content.ReadFromJsonAsync<UserDataDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CalculateCalories> Calculate(int id)
        {
            CalculateCalories calculateCalories = new CalculateCalories();
            var response = await httpClient.GetAsync($"api/UserData/{id}");
            if (response.IsSuccessStatusCode)
            {
              
             var userDataDto=  await response.Content.ReadFromJsonAsync<UserDataDto>();

                switch (userDataDto.Sex)
                {
                    case "Woman":
                        double kcalDemandWoman = 665 + (9.6 * userDataDto.Weight) + (1.8 * userDataDto.Height) - (4.7 * userDataDto.Age);
                        calculateCalories.DailyRequirementKcal=Math.Ceiling(KcalPAL(kcalDemandWoman, userDataDto.Activity));
                        calculateCalories.DailyRequirementCarbo = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.5) / 4);
                        calculateCalories.DailyRequirementProtein = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.2) / 4);
                        calculateCalories.DailyRequirementFat = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.3) / 9);
                        break;
                    case "Man":
                        double kcalDemandMan = 66 + (13.7 * userDataDto.Weight) + (5 * userDataDto.Height) - (6.8 * userDataDto.Age);
                        calculateCalories.DailyRequirementKcal = Math.Ceiling(KcalPAL(kcalDemandMan, userDataDto.Activity));

                        calculateCalories.DailyRequirementCarbo = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.5) / 4);

                        calculateCalories.DailyRequirementProtein = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.2) / 4);

                        calculateCalories.DailyRequirementFat = Math.Ceiling((calculateCalories.DailyRequirementKcal * 0.3) / 9);
                        break;
                }


            }
            return calculateCalories;
        }
        private double KcalPAL(double kcal, string PALActivity)
        {
            if (PALActivity == "Lackofphysicalactivity")
            {
                kcal = kcal * 1.2;
            }
            else if (PALActivity == "Lightactivity")
            {
                kcal = kcal * 1.4;
            }
            else if (PALActivity == "Averageactivity")
            {
                kcal = kcal * 1.6;
            }
            else if (PALActivity == "Highactivity")
            {
                kcal = kcal * 1.8;
            }
            else if (PALActivity == "Veryhighphysicalactivity")
            {
                kcal = kcal * 2.0;
            }
            return kcal;
        }
    }
}
