using Microsoft.UI.Xaml.Controls;
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

        //var teamBox = new TeamBox(); // TeamBox é o nome da sua classe que contém o código XAML acima
        //teamBox.BindingContext = viewModel.Times;
        //Content = teamBox;
    }
          

    //private void OnButtonClicked(object sender, EventArgs e)
    //{
    //    // Acesse a coleção Times aqui e exiba seus elementos
    //    foreach (var time in Times)
    //    {
    //        Console.WriteLine("Time: " + time.NomeTime);
    //        Console.WriteLine("Jogadores: ");
    //        foreach (var jogador in time.JogadorTime)
    //        {
    //            Console.WriteLine(jogador.NomeJogador + " - Nota: " + jogador.NotaJogador);
    //        }
    //    }
    //}





}