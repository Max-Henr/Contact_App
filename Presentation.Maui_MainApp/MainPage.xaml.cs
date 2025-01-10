using Presentation.Maui_MainApp.ViewModels;
using Microsoft.Maui.Controls;

namespace Presentation.Maui_MainApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}
