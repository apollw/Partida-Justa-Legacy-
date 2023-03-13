namespace Partida_Justa;

public partial class MenuPartida : ContentPage
{
	public MenuPartida()
	{
		InitializeComponent();
	}

    private async void MenuRegPartida(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuPartidaReg());

    }

    private async void MenuVerPartida(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuPartidaHist());

    }

    private async void MenuApagPartida(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuPartidaApagHist());

    }
}