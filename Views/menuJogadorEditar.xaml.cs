using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorEditar : ContentPage
{
    public menuJogadorEditar()
    {
        InitializeComponent();
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;      

        viewModel.OnCarregar();
        
    }
}