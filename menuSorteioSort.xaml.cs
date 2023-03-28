using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuSorteioSort : ContentPage
{
	public menuSorteioSort()
	{
		InitializeComponent();
        BindingContext = new JogadorViewModel();
    }


    private async void sortearEquipes(object sender, EventArgs e)
    {
        //// Obtém o ViewModel associado à página
        //JogadorViewModel viewModel = BindingContext as JogadorViewModel;

        //// Executa o comando EnviarCommand do ViewModel
        //if (viewModel.EnviarCommand.CanExecute(null))
        //    viewModel.EnviarCommand.Execute(null); 

    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);

            // Atribue a nota do jogador aqui
            var viewModel = (JogadorViewModel)BindingContext;
            //viewModel.NotaJogador = notaJogador;
        }
    }


}