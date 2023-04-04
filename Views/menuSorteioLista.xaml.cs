using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuSorteioLista : ContentPage
{
	public menuSorteioLista()
	{
        // Cria uma nova instância do ViewModel de Time
        var viewModel = new TimeViewModel();

        // Chama a função OnCarregarTimes() para carregar os dados do arquivo JSON
        viewModel.OnCarregarTimes();

        // Define o ViewModel como contexto de dados para a página
        BindingContext = viewModel;

        // Inicializa a página e carrega os componentes visuais
        InitializeComponent();        

        /*Em geral, no processo de inicialização de uma página, primeiro precisamos carregar os dados que serão exibidos nela. 
         * Neste caso, os dados que desejamos exibir são os times sorteados, que são carregados por meio da chamada ao método 
         * OnCarregarTimes() da instância viewModel da classe TimeViewModel. Então, ao chamar viewModel.OnCarregarTimes() antes
         * de inicializar o componente, estamos garantindo que os dados estarão disponíveis quando o componente for criado e configurado. 
         * Após o carregamento dos dados, é seguro inicializar o componente por meio da chamada ao método InitializeComponent(), 
         * que é responsável por carregar o arquivo XAML e renderizar a interface de usuário. 
         * Dessa forma, garantimos que os dados serão exibidos corretamente na tela, uma vez que foram carregados antes da 
         * inicialização do componente que os exibe.*/
    }
}