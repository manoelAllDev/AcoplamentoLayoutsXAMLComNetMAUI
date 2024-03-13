using F1.ViewMoldels;

namespace F1.Views;

public partial class WelcomePage : ContentPage
{
	private WelcomePageViewModel vm;
    public WelcomePage()
	{
        vm = new WelcomePageViewModel();
        BindingContext = vm;

        InitializeComponent();

    }
}