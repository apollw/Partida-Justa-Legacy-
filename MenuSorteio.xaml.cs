namespace Partida_Justa;

public partial class MenuSorteio : ContentPage
{
	public MenuSorteio()
	{
		InitializeComponent();
	}

    private async void MenuSortSorteio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuSorteioSort());

    }

    private async void MenuListaSorteio(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuSorteioLista());

    }
}