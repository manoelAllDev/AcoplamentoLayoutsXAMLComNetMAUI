using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using F1.Core;
using F1.Services.Ergast;
using F1.ViewMoldels;
using F1.Views.Controls;
using F1.Views.TabView;
using Microsoft.Extensions.Logging;

namespace F1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkitMarkup();


            //Pages
            builder.Services.AddTransient<HomeView>();

            //ViewModel
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<ViewModelLocator>();
            builder.Services.AddTransient<StateContainerViewModel>();

            //Service inject
            builder.Services.AddTransient<IErgastService, ErgastService>();
            builder.Services.AddTransient<HttpClientFactory>();

            






#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
