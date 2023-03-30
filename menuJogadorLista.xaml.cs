using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa;

public partial class menuJogadorLista : ContentPage
{
	public menuJogadorLista()
	{
        InitializeComponent();
        // Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregar();
   
    }
}