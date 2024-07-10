using Microsoft.Maui.Controls;
using progreso3mj.Services;
using progreso3mj.ViewModels;

namespace progreso3mj.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MealSearchViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            var mealService = new MealService();
            var mealDatabase = new MealDatabase(FileAccessHelper.GetLocalFilePath("meals.db3"));
            _viewModel = new MealSearchViewModel(mealService, mealDatabase);
            BindingContext = _viewModel;
        }

        private async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new progreso3mj.HistoryPage());
        }
    }
}
