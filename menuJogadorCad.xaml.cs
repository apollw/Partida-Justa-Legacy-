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

    //Elemento de Slider que altera os valores à medida que o usuário desliza o elemento na tela
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {

        // Obtém o ViewModel associado à página
        var viewModel = BindingContext as JogadorViewModel;

        //// Executa o comando EnviarCommand do ViewModel
        //if (viewModel.EnviarCommand.CanExecute(null))
        //    viewModel.EnviarCommand.Execute(null);

        double value = (int)args.NewValue;

        //Controle do Slider para responder a valores inteiros
        switch (value)
        {
            case 1:
                displayLabel.Text = String.Format("Nível 1");
                // Atualiza a propriedade NotaJogador com o novo valor do slider
                viewModel.NotaJogador = 1;
                break;
            case 2:
                displayLabel.Text = String.Format("Nível 2");
                viewModel.NotaJogador = 2;
                break;
            case 3:
                displayLabel.Text = String.Format("Nível 3");
                viewModel.NotaJogador = 3;
                break;
            case 4:
                displayLabel.Text = String.Format("Nível 4");
                viewModel.NotaJogador = 4;
                break;
            case 5:
                displayLabel.Text = String.Format("Nível 5");
                viewModel.NotaJogador = 5;
                break;
            default:
                // Você pode colocar algum código para lidar com valores inválidos aqui
                break;

            //case >= 0 and < 1:
            //    displayLabel.Text = String.Format("Nível 1");
            //    // Atualiza a propriedade NotaJogador com o novo valor do slider
            //    viewModel.NotaJogador = 1;
            //    break;
            //case >= 1 and < 2:
            //    displayLabel.Text = String.Format("Nível 2");
            //    viewModel.NotaJogador = 2;
            //    break;
            //case >= 2 and < 3:
            //    displayLabel.Text = String.Format("Nível 3");
            //    viewModel.NotaJogador = 3;
            //    break;
            //case >= 3 and < 4:
            //    displayLabel.Text = String.Format("Nível 4");
            //    viewModel.NotaJogador = 4;
            //    break;
            //case >= 4 and <= 5:
            //    displayLabel.Text = String.Format("Nível 5");
            //    viewModel.NotaJogador = 5;
            //    break;
            //default:
            //    // Você pode colocar algum código para lidar com valores inválidos aqui
            //    break;
        }
    }
}