using F1.ViewMoldels;
using F1.Views.Controls;

namespace F1.Views.TabView;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}