using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using progreso3mj.Models;

namespace progreso3mj.Services
{
    public class MealDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public MealDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MealMJ>().Wait();
            _database.CreateTableAsync<SearchHistoryMJ>().Wait();
        }

        public Task<List<MealMJ>> GetMealsAsync()
        {
            return _database.Table<MealMJ>().ToListAsync();
        }

        public Task<int> SaveMealAsync(MealMJ meal)
        {
            return _database.InsertAsync(meal);
        }

        public Task<int> SaveSearchHistoryAsync(SearchHistoryMJ history)
        {
            return _database.InsertAsync(history);
        }

        public Task<List<SearchHistoryMJ>> GetSearchHistoryAsync()
        {
            return _database.Table<SearchHistoryMJ>().ToListAsync();
        }
    }
}
