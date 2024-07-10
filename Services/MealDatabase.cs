using progreso3mj.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
