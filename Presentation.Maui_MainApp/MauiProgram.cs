using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.Logging;
using Presentation.Maui_MainApp.ViewModels;

namespace Presentation.Maui_MainApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IFileService, FileService>();

    		builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
