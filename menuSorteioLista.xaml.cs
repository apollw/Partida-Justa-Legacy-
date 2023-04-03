using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuSorteioLista : ContentPage
{
	public menuSorteioLista()
	{
		InitializeComponent();

        var viewModel = new TimeViewModel();
        BindingContext = viewModel;

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregarTimes();
    }
}

