namespace Partida_Justa;

public partial class menuJogadorCad : ContentPage
{
	public menuJogadorCad()
	{
		InitializeComponent();
	}

    private async void cadastrarJogador(object sender, EventArgs e)
    {
        //Quando o usuário clicar em "Cadastrar Jogador", o jogador é salvo na lista
        //Exibe o alerta que a operação foi bem sucedida
        //string nome = Entry.Text;

        //Para fazer Vinculação de Dados do Botão que foi definido na View, precisamos
        //definir uma BindingContext

        await DisplayAlert("Alerta", "Jogador Incluído com Sucesso!", "Concluir");

        //Falta implementar o tratamento de erro para caso o nome do jogador já exista 
        //na lista

    }

    //Elemento de Slider que altera os valores à medida que o usuário desliza o elemento na tela
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;

        if(value>=0&&value<1)
            displayLabel.Text = String.Format("Nível 1");
        if (value >= 1 && value <2)
            displayLabel.Text = String.Format("Nível 2");
        if (value >= 2 && value <3)
            displayLabel.Text = String.Format("Nível 3");
        if (value >= 3 && value <4)
            displayLabel.Text = String.Format("Nível 4");
        if (value >= 4 && value <= 5)
            displayLabel.Text = String.Format("Nível 5");

    }
}