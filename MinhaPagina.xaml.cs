namespace Partida_Justa;

public partial class MinhaPagina : ContentPage
{
	public MinhaPagina()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
		//Quando eu clicar no Button, ele irá navegar pra MainPage
    }
}