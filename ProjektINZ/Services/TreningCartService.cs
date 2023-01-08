using KlalorieOnline.Models.Dtos;
using KlalorieOnline.Models.Dtos.TreningDtos;
using Newtonsoft.Json;
using ProjektINZ.Services.Contracts;
using System.Net.Http.Json;
using System.Text;

namespace ProjektINZ.Services
{
    public class TreningCartService : ITreningCartService
    {


        private readonly HttpClient httpClient;

        public TreningCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<TreningCartItemDto> AddExercise(TreningCartItemToAddDto treningCartItemToAddDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<TreningCartItemToAddDto>("api/TreningCart", treningCartItemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TreningCartItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<TreningCartItemDto>();

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

        public async Task<TreningCartToAddDto> AddTreningCart(TreningCartToAddDto treningCartToAddDto)
        {
            try
            {


                var response = await httpClient.PostAsJsonAsync<TreningCartToAddDto>("api/TreningCart/postByUserId", treningCartToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TreningCartToAddDto);
                    }

                    return await response.Content.ReadFromJsonAsync<TreningCartToAddDto>();

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

        public async Task<TreningCartItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/TreningCart/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TreningCartItemDto>();
                }
                return default(TreningCartItemDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<TreningCartItemDto>> GetExercises(int cartId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/TreningCart/{cartId}/GetExercises");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TreningCartItemDto>();/*.ToList()*/;
                    }
                    return await response.Content.ReadFromJsonAsync<List<TreningCartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public async Task<IEnumerable<TreningCartDto>> GetUserTreningCarts(int userId)
        {
            try
            {
                var userDataDtos = await this.httpClient.GetFromJsonAsync<IEnumerable<TreningCartDto>>($"api/TreningCart/getCartsByUserId{userId}");
                return userDataDtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TreningCartItemDto> UpdateTreningCart(TreningCartUpdateDto treningCartUpdateDto)
        {
            try
            {
                var jsonReqest = JsonConvert.SerializeObject(treningCartUpdateDto);
                var content = new StringContent(jsonReqest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/TreningCart/{treningCartUpdateDto.TreningCartItemId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TreningCartItemDto>();
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
