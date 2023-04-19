using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa.Views;

public partial class menuJogadorEdicao : ContentPage
{
    private ModelJogador _jogador;

    //JogadorViewModel viewModel = new JogadorViewModel();


    public menuJogadorEdicao(ModelJogador jogador)
    {
        InitializeComponent();

        //// Define o BindingContext da página para uma nova instância da classe JogadorViewModel
        //BindingContext = new JogadorViewModel();
        //BindingContext = viewModel;

        // Salva a referência ao jogador
        _jogador = jogador;
        // Define o contexto de vinculação para a página
        BindingContext = _jogador;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // Obtém o ViewModel associado à página
        JogadorViewModel viewModel = BindingContext as JogadorViewModel;
        bool confirmado = false;

        if (viewModel.ObjJogador.Nome == string.Empty)
            await DisplayAlert("Alerta", "O nome do Jogador não foi informado!", "Concluir");
        else if (viewModel.ObjJogador.Nota == 0)
            await DisplayAlert("Alerta", "A nota do Jogador não foi informada!", "Concluir");
        else
        {
            // Salva as alterações aqui
            _jogador.Nome = entry.Text;
            //_jogador.Nota = viewModel.NotaJogador;

            ////Salva as alterações
            //var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            ////Serializa a lista atualizada de volta para uma string JSON
            //string json = JsonConvert.SerializeObject(Jogadores);
            //// Salva a string JSON atualizada no arquivo
            //File.WriteAllText(filePath, json);

            await DisplayAlert("Alerta", "Jogador Editado com Sucesso!", "Concluir");
            viewModel.NomeJogador = string.Empty;
            viewModel.NotaJogador = 0;
            picker.SelectedIndex = -1;
            confirmado = true;
        }

        if (confirmado == true)
            await Navigation.PopModalAsync();
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);

            // Atribue a nota do jogador aqui
            //var viewModel = (JogadorViewModel)BindingContext;
            //viewModel.NotaJogador = notaJogador;

            _jogador.Nota = notaJogador;
        }
    }
}