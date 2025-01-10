using Presentation.Maui_MainApp.ViewModels;

namespace Presentation.Maui_MainApp;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(MainViewModel viewModel)
    {
        
        InitializeComponent();
        BindingContext = viewModel;
    }
}