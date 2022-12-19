
using KlalorieOnline.Models.Dtos;
using Newtonsoft.Json;
using ProjektINZ.Services.Contracts;
using ShopOnline.Models.Dtos;
using System.Net.Http.Json;
using System.Text;

namespace ProjektINZ.Services
{
    public class DayCartService : IDayCartService
    {
        private readonly HttpClient httpClient;

        public DayCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CartToAddDto> AddCart(CartToAddDto cartToAddDto)
        {
            try
            {


                var response = await httpClient.PostAsJsonAsync<CartToAddDto>("api/DayCart/postByUserId", cartToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartToAddDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartToAddDto>();

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

        public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartItemToAddDto>("api/DayCart", cartItemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();

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

        public async Task<CartItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/DayCart/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                return default(CartItemDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<CartDto> GetCartByUserID(int UserId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/DayCart/getByUserId{UserId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartDto);

                    }
                    return await response.Content.ReadFromJsonAsync<CartDto>();

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

        public async Task<IEnumerable<CartItemDto>> GetItems(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/DayCart/{userId}/GetItems");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>();/*.ToList()*/;
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
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

        public async Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            try
            {
                var jsonReqest=JsonConvert.SerializeObject(cartItemQtyUpdateDto);
                var content = new StringContent(jsonReqest,Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/DayCart/{cartItemQtyUpdateDto.CartItemId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
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
