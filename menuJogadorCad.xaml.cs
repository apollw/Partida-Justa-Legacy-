using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorCad : ContentPage
{
	public menuJogadorCad()
	{
		InitializeComponent();
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        BindingContext = new JogadorViewModel();
    }

    // Evento Clicked do botão para adicionar o jogador à lista de jogadores usando as propriedades
    // Nome e Nota do ViewModel
    private async void cadastrarJogador(object sender, EventArgs e)
    {
        //Quando o usuário clicar em "Cadastrar Jogador", o jogador é salvo na lista
        //Exibe o alerta que a operação foi bem sucedida
        //Para fazer Vinculação de Dados do Botão que foi definido na View, precisamos
        //definir uma BindingContext

        // Obtém o ViewModel associado à página
        var viewModel = BindingContext as JogadorViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.EnviarCommand.CanExecute(null))
            viewModel.EnviarCommand.Execute(null);

        await DisplayAlert("Alerta", "Jogador Incluído com Sucesso!", "Concluir");

       //Falta implementar o tratamento de erro para caso o nome do jogador já exista 
       //na lista
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);
            // Atribua a nota do jogador aqui
            var viewModel = (JogadorViewModel)BindingContext;
            viewModel.NotaJogador = notaJogador;
        }
    }

}