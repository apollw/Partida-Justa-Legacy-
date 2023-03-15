namespace Partida_Justa;

public partial class menuSorteioSort : ContentPage
{
	public menuSorteioSort()
	{
		InitializeComponent();
	}

	
    private async void sortearEquipes(object sender, EventArgs e)
    {
        // Obter o texto da caixa de texto
        string nome = NomeEntry.Text; //Eu utilizo o nome associado à entry para dispara o evento

        //Converto a entrada de string para int 
        //Se o número estiver fora do intervalo, exibe alerta e não adiciona
        if (  !(int.Parse(NomeEntry.Text)>=1&& int.Parse(NomeEntry.Text)<=10)  )
            await DisplayAlert("Alerta", "Digite um número válido", "Fechar");
        else
            await DisplayAlert("Alerta", "Times Sorteados com Sucesso!", "Fechar");
        //Ainda falta implementar aqui a lógica de sorteio
    }
}