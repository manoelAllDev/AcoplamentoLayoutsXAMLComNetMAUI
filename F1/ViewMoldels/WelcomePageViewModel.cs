using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace F1.ViewMoldels
{
    [ObservableObject]
    public partial class WelcomePageViewModel
    {


        [RelayCommand]
        private async void LetsStart()
        {
            await Shell.Current.GoToAsync("///main");
        }

    }
}
