using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa.Views;

public partial class menuSorteioPresenca : ContentPage
{
    public ObservableCollection<ModelJogador> MyItems { get; set; }
    public Dictionary<string, bool> selectedValues = new Dictionary<string, bool>(); //Para as Switches

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

        //Método para marcar todos os jogadores da SwitchCell
        var selectAllCell = new TextCell { Text = "Selecionar todos" };
        selectAllCell.Tapped += (s, e) =>
        {
            foreach (var switchCell in switchCells)
            {
                switchCell.On = true;
            }
            foreach (var jogador in MyItems)
            {
                jogador.Presente = true;
            }
            // Salvar as informações atualizadas no arquivo JSON
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            string json = JsonConvert.SerializeObject(MyItems);
            File.WriteAllText(filePath, json);
        };
        tableSection.Add(selectAllCell);

        //Método para selecionar um de cada vez
        foreach (var jogador in MyItems)
        {
            var switchCell = new SwitchCell { Text = jogador.Nome };
            switchCell.OnChanged += (s, e) =>
            {
                // Marcar ou desmarcar o jogador como presente
                jogador.Presente = e.Value;

                // Salvar as informações atualizadas no arquivo JSON
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
                string json = JsonConvert.SerializeObject(MyItems);
                File.WriteAllText(filePath, json);

            };
            tableSection.Add(switchCell);
            switchCells.Add(switchCell); // Adicionar à lista switchCells            
        }

    }

    async void OnConfirmButtonClicked(object sender, EventArgs e)
    {                
        await Navigation.PushAsync(new menuSorteioSort());
    }


}

