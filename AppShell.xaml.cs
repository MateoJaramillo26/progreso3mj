using Microsoft.Maui.Controls;
using progreso3mj.Views;

namespace progreso3mj
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
        }
    }
}
