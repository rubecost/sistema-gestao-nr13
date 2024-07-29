using CommunityToolkit.Maui;
using Cronos.Services;
using Cronos.Platforms.Windows;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Cronos
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseSkiaSharp()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");
					fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
					fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
					fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
					fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");

					fonts.AddFont("icons.ttf", "icons");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
