using MauiApp15.Modelo;
using MauiApp15.Repositorios;

namespace MauiApp15;

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
		String ruta = obtenerRutaBD.devolverRuta("totalAlumnos.db");
        builder.Services.AddSingleton<AlumnoRepositorio>(
            s => ActivatorUtilities.CreateInstance<AlumnoRepositorio>(s, ruta)
            );
        return builder.Build();
	}
}
