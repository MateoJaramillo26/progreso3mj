using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using progreso3mj.Models;

namespace progreso3mj.Services
{
    public class MealService
    {
        private readonly HttpClient _httpClient;

        public MealService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<MealMJ[]> SearchMealsAsync(string searchTerm)
        {
            var response = await _httpClient.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/search.php?s={searchTerm}");
            var result = JsonConvert.DeserializeObject<MealResponse>(response);
            return result.Meals ?? new MealMJ[0];
        }
    }

    public class MealResponse
    {
        [JsonProperty("meals")]
        public MealMJ[] Meals { get; set; }
    }
}
