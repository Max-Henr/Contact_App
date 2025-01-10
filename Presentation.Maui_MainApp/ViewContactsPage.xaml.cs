using Presentation.Maui_MainApp.ViewModels;

namespace Presentation.Maui_MainApp;

public partial class ViewContactsPage : ContentPage
{
	public ViewContactsPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}