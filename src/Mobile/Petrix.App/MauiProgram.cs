using Microsoft.Extensions.Logging;

namespace Petrix.App
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
                    fonts.AddFont("Raleway-Black.ttf", "RalewayBlack");
                    fonts.AddFont("Raleway-Thin.ttf", "RalewayThin");
                    fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                    fonts.AddFont("WorkSans-Black.ttf", "WorkSansBlack");
                    fonts.AddFont("WorkSans-Regular.ttf", "WorkSansRegular");
                });

            return builder.Build();
        }
    }
}
