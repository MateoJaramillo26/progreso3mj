using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using progreso3mj.Models;
using System.Collections.Generic;

namespace progreso3mj.Services
{
    public class MealService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BaseUrl = "https://www.themealdb.com/api/json/v1/1/";

        public async Task<List<MealMJ>> SearchMealsAsync(string mealName)
        {
            var url = $"{BaseUrl}search.php?s={mealName}";
            HttpResponseMessage response = null;

            try
            {
                response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                // Log the exception (use una herramienta de logging o System.Diagnostics.Debug)
                System.Diagnostics.Debug.WriteLine($"Request exception: {e.Message}");
                throw;
            }

            var json = await response.Content.ReadAsStringAsync();
            var mealResponse = JsonSerializer.Deserialize<MealResponse>(json);

            return mealResponse.Meals ?? new List<MealMJ>();
        }

        private class MealResponse
        {
            public List<MealMJ> Meals { get; set; }
        }
    }
}
