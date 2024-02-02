using MauiApp15.Repositorios;

namespace MauiApp15;

public partial class App : Application
{
	public AlumnoRepositorio alumnoRepositorio { get; set; }
	public App(AlumnoRepositorio _alumnoRepositorio)
	{
		alumnoRepositorio= _alumnoRepositorio;
		InitializeComponent();

		MainPage = new AppShell();
	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Launcher.OpenAsync(new Uri("https://www.linkedin.com/in/jonas-gomez-garcia/"));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Navigation hacia el inicio de sesión
    }
}
