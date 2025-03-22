using LoginApp.Core.Interfaces;
using LoginApp.Core.Services;
using LoginApp.Core.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace LoginApp;

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
                fonts.AddFont("fontello.ttf", "Icons");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        ModifyEntryHandler();

        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddTransient<LoginViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void ModifyEntryHandler()
    {
        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
            #if ANDROID
            handler.PlatformView.Background = null;
            #endif

        });
    }
}
