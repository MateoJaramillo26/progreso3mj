using Microsoft.Maui.Controls;
using progreso3mj.Services;
using progreso3mj.ViewModels;

namespace progreso3mj.Views
{
    public partial class HistoryPage : ContentPage
    {
        private readonly MealSearchViewModel _viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            var mealService = new MealService();
            var mealDatabase = new MealDatabase(FileAccessHelper.GetLocalFilePath("meals.db3"));
            _viewModel = new MealSearchViewModel(mealService, mealDatabase);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadHistoryCommand.ExecuteAsync(null);
        }
    }
}
