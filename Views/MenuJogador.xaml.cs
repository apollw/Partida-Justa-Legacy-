using Partida_Justa.Models;

namespace Partida_Justa;

public partial class MenuJogador : ContentPage
{
	public MenuJogador()
	{
		InitializeComponent();
	}

    private async void MenuCadJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorCad());
    }

    private async void MenuLimparLista(object sender, EventArgs e)
    {   
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        bool answer = await DisplayAlert("Alerta", "Tem certeza que deseja limpar a lista?", "Sim", "Não");
        if (answer)
        {
           bool answer2 = await DisplayAlert("Alerta", "A exclusão não pode ser desfeita. Deseja continuar?", "Sim", "Não");
           if (answer2)
           {
                    viewModel.OnExcluir();
                    await Navigation.PopAsync();
           }
        }
        else
        {
            await Navigation.PopAsync();
        }
    }
    private async void MenuEditarJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorEditar());
    }

    private async void MenuListarJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorLista());
    }

}