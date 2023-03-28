using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorEditar : ContentPage
{
    public menuJogadorEditar()
    {
        InitializeComponent();
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        /*Outra maneira*/
        //public MainPage(MainViewModel vm)
        //{
        //    InitializeComponent();
        //    BindingContext = vm;
        //}

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregar();

    }


    //private async void editarJogador(object sender, EventArgs e)
    //{
    //    // Obtém o ViewModel associado à página
    //    JogadorViewModel viewModel = BindingContext as JogadorViewModel;

    //    // Chama a função OnCarregar para carregar os dados do arquivo JSON
    //    viewModel.OnCarregar();

    //    //// Executa o comando EnviarCommand do ViewModel
    //    //if (viewModel.EnviarCommand.CanExecute(null))
    //    //    viewModel.EnviarCommand.Execute(null);

    //    //viewModel.OnEditar();

    //}

    //private async void removerJogador(object sender, EventArgs e)
    //{
    //    // Obtém o ViewModel associado à página
    //    JogadorViewModel viewModel = BindingContext as JogadorViewModel;

    //    // Executa o comando EnviarCommand do ViewModel
    //    if (viewModel.EnviarCommand.CanExecute(null))
    //        viewModel.EnviarCommand.Execute(null);

    //    viewModel.OnEditar();

    //    if (viewModel.ObjJogador.Nome == string.Empty)
    //        await DisplayAlert("Alerta", "O nome do Jogador não foi informado!", "Concluir");
    //    else if (viewModel.Encontrado == true)
    //    {
    //        await DisplayAlert("Alerta", "Jogador Encontrado!", "Concluir");
    //    }
    //    else
    //        await DisplayAlert("Alerta", "Jogador Não Encontrado!", "Concluir");
    //}



}