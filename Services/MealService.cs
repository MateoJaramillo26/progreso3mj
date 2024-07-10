using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using progreso3mj.Models;

namespace progreso3mj.Services
{
    public class MealService
    {
        
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BaseUrl = "https://www.themealdb.com/api/json/v1/1/";

        public async Task<MealMJ> SearchMealAsync(string mealName)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}search.php?s={mealName}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var mealResponse = JsonSerializer.Deserialize<MealResponse>(json);

            return mealResponse.Meals?.FirstOrDefault();
        }

        private class MealResponse
        {
            public MealMJ[] Meals { get; set; }
        }
    }
}
