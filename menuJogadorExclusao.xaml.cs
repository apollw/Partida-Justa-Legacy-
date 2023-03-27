using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorExclusao : ContentPage
{
	public menuJogadorExclusao()
	{
		InitializeComponent();
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        BindingContext = new JogadorViewModel();
    }

    private async void excluirJogador(object sender, EventArgs e)
    {
        // Obtém o ViewModel associado à página
        JogadorViewModel viewModel = BindingContext as JogadorViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.EnviarCommand.CanExecute(null))
            viewModel.EnviarCommand.Execute(null);

        if (viewModel.ObjJogador.Nome == string.Empty)
            await DisplayAlert("Alerta", "O nome do Jogador não foi informado!", "Concluir");

        else if (viewModel.Encontrado == true)
        {
            await DisplayAlert("Alerta", "Jogador Encontrado!", "Concluir");
            bool answer = await DisplayAlert("Alerta", "Tem certeza que quer excluir?", "Sim", "Não");

            if (answer)
            {
                viewModel.OnExcluirJogador();
                await DisplayAlert("Alerta", "Jogador Excluído com Sucesso!", "Concluir");
            }

            //viewModel.NomeJogador = string.Empty;
            //viewModel.NotaJogador = 0;    

        }
        else
            await DisplayAlert("Alerta", "Jogador Não Encontrado!", "Concluir");
    
    }
}

