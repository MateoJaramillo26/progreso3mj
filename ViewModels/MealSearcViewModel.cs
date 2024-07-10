using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using progreso3mj.Models;
using progreso3mj.Services;

namespace progreso3mj.ViewModels
{
    public class MealSearchViewModel : ObservableObject
    {
        private readonly MealService _mealService;
        private readonly MealDatabase _mealDatabase;

        public ObservableCollection<MealMJ> Meals { get; } = new ObservableCollection<MealMJ>();
        public ObservableCollection<SearchHistoryMJ> SearchHistories { get; } = new ObservableCollection<SearchHistoryMJ>();

        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public MealSearchViewModel(MealService mealService, MealDatabase mealDatabase)
        {
            _mealService = mealService;
            _mealDatabase = mealDatabase;

            SearchCommand = new AsyncRelayCommand(SearchMealAsync);
            LoadHistoryCommand = new AsyncRelayCommand(LoadHistoryAsync);
        }

        public IAsyncRelayCommand SearchCommand { get; }
        public IAsyncRelayCommand LoadHistoryCommand { get; }

        private async Task SearchMealAsync()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var meal = await _mealService.SearchMealAsync(SearchTerm);
                if (meal != null)
                {
                    Meals.Clear();
                    Meals.Add(meal);

                    await _mealDatabase.SaveMealAsync(meal);
                    await _mealDatabase.SaveSearchHistoryAsync(new SearchHistoryMJ
                    {
                        SearchTerm = SearchTerm,
                        SearchDate = DateTime.Now
                    });

                    await LoadHistoryAsync();
                }
            }
        }

        private async Task LoadHistoryAsync()
        {
            SearchHistories.Clear();
            var histories = await _mealDatabase.GetSearchHistoryAsync();
            foreach (var history in histories)
            {
                SearchHistories.Add(history);
            }
        }
    }
}
