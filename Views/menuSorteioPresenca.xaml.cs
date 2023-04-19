using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa.Views;

public partial class menuSorteioPresenca : ContentPage
{
    public ObservableCollection<ModelJogador> MyItems { get; set; }
    public menuSorteioPresenca()
	{
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        viewModel.OnCarregar();

        InitializeComponent();

        MyItems = new ObservableCollection<ModelJogador>();
        MyItems = viewModel.Jogadores;

	}

    void OnConfirmSwipeItemInvoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var item = swipeItem.BindingContext as ModelJogador;

        foreach(ModelJogador element in  MyItems)
        {
            if (element.Nome == item.Nome)
            {
                element.Presente = true;
                break;
            }
        }
        
        //Reescreve informação na Lista Geral antes do sorteio
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
        //Serializa a lista atualizada de volta para uma string JSON
        string json = JsonConvert.SerializeObject(MyItems);
        // Salva a string JSON atualizada no arquivo
        File.WriteAllText(filePath, json);
    }


}

