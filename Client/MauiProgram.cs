using Client.Repositories;
using Client.Services;
using Client.ViewModels;
using Client.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterRepositories()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddHttpClient("MauiClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5168/api");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IPersonService, PersonService>();
            builder.Services.AddTransient<INavigationService, NavigationService>();

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<PersonListOverviewViewModel>();

            builder.Services.AddTransient<PersonDetailViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<PersonOverviewPage>();

            builder.Services.AddTransient<PersonDetailPage>();
            return builder;
        }
    }
}
