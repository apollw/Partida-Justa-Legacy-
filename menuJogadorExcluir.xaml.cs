using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuJogadorExcluir : ContentPage
{
	public menuJogadorExcluir()
	{

        InitializeComponent();
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;
    }


    // Evento Clicked do botão para adicionar o jogador à lista de jogadores usando as propriedades
    // Nome e Nota do ViewModel
    private async void excluirJogador(object sender, EventArgs e)
    {
        //Quando o usuário clicar em "Cadastrar Jogador", o jogador é salvo na lista
        //Exibe o alerta que a operação foi bem sucedida
        //Para fazer Vinculação de Dados do Botão que foi definido na View, precisamos
        //definir uma BindingContext

        // Obtém o ViewModel associado à página
        var viewModel = BindingContext as JogadorViewModel;

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnExcluir();

        await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");

        //Falta implementar o tratamento de erro para caso o nome do jogador já exista 
        //na lista
    }


}