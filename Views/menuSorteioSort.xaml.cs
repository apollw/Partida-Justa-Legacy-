using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuSorteioSort : ContentPage
{
	public menuSorteioSort()
	{
		InitializeComponent();
        BindingContext = new TimeViewModel();
    }

    private async void sortearTimes(object sender, EventArgs e)
    {
        // Obtém o ViewModel associado à página
        TimeViewModel viewModel = BindingContext as TimeViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.SortearCommand.CanExecute(null))
            viewModel.SortearCommand.Execute(null);

        if (viewModel.Criado == true)
        {
            await DisplayAlert("Alerta", "Times criados com sucesso!", "Concluir");
            await Navigation.PushAsync(new menuSorteioLista());
        }
        else
            await DisplayAlert("Alerta", "Nenhum time foi gerado", "Fechar");

    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int valor = int.Parse((string)picker.ItemsSource[selectedIndex]);

            // Atribue a nota do jogador aqui
            var viewModel = (TimeViewModel)BindingContext;

            if(valor!=0)
                viewModel.tamanhoEquipe = valor;
        }
    }

}