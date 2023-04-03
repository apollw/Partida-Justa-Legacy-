using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa;

public partial class menuJogadorLista : ContentPage
{
	public menuJogadorLista()
	{
        InitializeComponent();
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregar();
   
    }
}