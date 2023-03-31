//using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa;

public partial class menuSorteioLista : ContentPage
{
	public menuSorteioLista()
	{
		InitializeComponent();
        var viewModel = new TimeViewModel();
        BindingContext = viewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.CarregarCommand.CanExecute(null))
            viewModel.CarregarCommand.Execute(null);

        // Chama a função OnCarregar para carregar os dados do arquivo JSON
        //viewModel.OnCarregarTimes();
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