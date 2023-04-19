using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa.Views;

public partial class menuSorteioPresenca : ContentPage
{
    public ObservableCollection<ModelJogador> MyItems { get; set; }
    private List<SwitchCell> switchCells = new List<SwitchCell>();
    public menuSorteioPresenca()
	{
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        viewModel.OnCarregar();
        InitializeComponent();

        MyItems = new ObservableCollection<ModelJogador>();
        MyItems = viewModel.Jogadores;

        var tableSection = JogadoresTableView.Root[0];

        var selectAllCell = new TextCell { Text = "Selecionar todos" };
        selectAllCell.Tapped += (s, e) =>
        {
            foreach (var switchCell in switchCells)
            {
                switchCell.On = !switchCell.On;
            }
        };
        tableSection.Add(selectAllCell);

        foreach (var jogador in MyItems)
        {
            var switchCell = new SwitchCell { Text = jogador.Nome };
            switchCell.OnChanged += (s, e) =>
            {
                // Marcar ou desmarcar o jogador como presente
                jogador.Presente = e.Value;
            };
            tableSection.Add(switchCell);
        }

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

