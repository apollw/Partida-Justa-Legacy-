using Partida_Justa.Models;

namespace Partida_Justa;

public partial class MenuJogador : ContentPage
{
	public MenuJogador()
	{
		InitializeComponent();
	}

    //Cria��o de Eventos Ass�ncronos

    private async void MenuCadJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorCad());
    }

    private async void MenuLimparLista(object sender, EventArgs e)
    {   
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        bool answer = await DisplayAlert("Alerta", "Tem certeza que deseja limpar a lista?", "Sim", "N�o");
        if (answer)
        {
           bool answer2 = await DisplayAlert("Alerta", "A exclus�o n�o pode ser desfeita. Deseja continuar?", "Sim", "N�o");
           if (answer2)
           {
                    viewModel.OnExcluir();
                    await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");
                    await Navigation.PopAsync();
           }
        }
        else
        {
            await DisplayAlert("Alerta", "A lista n�o foi alterada", "Concluir");
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