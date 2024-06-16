using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RecipesPlan.Domain.Interfaces.Cash;
using RecipesPlan.Domain.Interfaces.Repository;
using RecipesPlan.Infrastructure.Data.Database.Context;
using RecipesPlan.Infrastructure.RepositoryImplementation;
using RecipesPlan.Presentation.Cash;
using RecipesPlan.Presentation.Modules.Internet.View;
using RecipesPlan.Presentation.Modules.Internet.ViewModel;
using RecipesPlan.Presentation.Modules.Main.View;
using RecipesPlan.Presentation.Modules.Main.ViewModel;
using RecipesPlan.Presentation.Modules.Schedule.View;
using RecipesPlan.Presentation.Modules.Schedule.ViewModel;
using System.Net.NetworkInformation;
using System.Reflection;

namespace RecipesPlan
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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif 

            // infrastructure layer
            builder.Services.AddSingleton<IRecipeRepository, RecipeRepositoryImpl>();
            builder.Services.AddSingleton<ILocalDbService, LocalDbService>();

            // domain layer
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            builder.Services.AddSingleton<IRecipesCash, RecipesCash>();

            // presentation layer
            builder.Services.AddSingleton<SchedulePageVM>();
            builder.Services.AddSingleton<SchedulePage>();

            builder.Services.AddSingleton<MainPageVM>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<RecipesPageVM>();
            builder.Services.AddSingleton<RecipesPage>();

            builder.Services.AddTransient<RecipesPageVM>();

            return builder.Build();
        }
    }
}