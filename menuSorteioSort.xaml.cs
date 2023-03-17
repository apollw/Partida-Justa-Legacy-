namespace Partida_Justa;

public partial class menuSorteioSort : ContentPage
{
	public menuSorteioSort()
	{
		InitializeComponent();
	}

	
    private async void sortearEquipes(object sender, EventArgs e)
    {
    //    // Obter o texto da caixa de texto
    //    //string nome = NomeEntry.Text; //Eu utilizo o nome associado à entry para dispara o evento

    //    //Converto a entrada de string para int 
    //    //Se o número estiver fora do intervalo, exibe alerta e não adiciona
    //    /*if (  !(int.Parse(NomeEntry.Text)>=1&& int.Parse(NomeEntry.Text)<=10)  )
    //        await DisplayAlert("Alerta", "Digite um número válido", "Fechar");
    //    else
    //        await DisplayAlert("Alerta", "Times Sorteados com Sucesso!", "Fechar");*/
    //    //Ainda falta implementar aqui a lógica de sorteio


    //    //Adicionar Tratamento de erro para caso o usuário entre com uma string ao invés de um número
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;

        if (value >= 0 && value < 2)
            displayLabel.Text = String.Format("2 Jogadores");
        if (value >= 2 && value < 3 )
            displayLabel.Text = String.Format("3 Jogadores");
        if (value >= 3 && value < 4)
            displayLabel.Text = String.Format("4 Jogadores");
        if (value >= 4 && value < 5)
            displayLabel.Text = String.Format("5 Jogadores");
        if (value >= 5 && value <= 6)
            displayLabel.Text = String.Format("6 Jogadores");
        if (value >= 6 && value <= 7)
            displayLabel.Text = String.Format("7 Jogadores");
        if (value >= 7 && value <= 8)
            displayLabel.Text = String.Format("8 Jogadores");
        if (value >= 8 && value <= 9)
            displayLabel.Text = String.Format("9 Jogadores");
        if (value >= 9 && value <= 10)
            displayLabel.Text = String.Format("10 Jogadores");
        if (value >= 10 && value <= 11)
            displayLabel.Text = String.Format("11 Jogadores");
    }
}