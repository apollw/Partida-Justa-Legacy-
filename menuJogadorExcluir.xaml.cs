using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuJogadorExcluir : ContentPage
{
	public menuJogadorExcluir()
	{
        InitializeComponent();
    }

    private async void apagarLista(object sender, EventArgs e)
    {
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

       bool answer = await DisplayAlert("Alerta", "Tem certeza que deseja limpar a lista?", "Sim", "Não");
        if (answer)
        {
            bool answer2 = await DisplayAlert("Alerta", "A exclusão não pode ser desfeita. Deseja continuar?", "Sim", "Não");
            if (answer2)
            {
                viewModel.OnExcluir();
                await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");
                await Navigation.PopAsync();
            }
        }
        else
        {
            await DisplayAlert("Alerta", "A lista não foi alterada", "Concluir");
            await Navigation.PopAsync();
        }
    }

}