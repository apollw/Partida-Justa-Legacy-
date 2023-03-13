namespace Partida_Justa;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

  
    private async void MenuNavJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuJogador());
    }

    private async void MenuNavSorteio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuSorteio());
    }

    private async void MenuNavPartida(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuPartida());
    }


}

