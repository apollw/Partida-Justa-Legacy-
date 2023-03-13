namespace Partida_Justa;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //Para ocorrer a navegação, precisamos primeiro criar a pilha de nav        

        /*Página Inicial*/
        var navPage = new NavigationPage(new MinhaPagina());
        MainPage = navPage;

        //Alterando propriedades das páginas
        navPage.BarBackgroundColor = Colors.ForestGreen;
        navPage.BarTextColor = Colors.White;

        /*Menu Principal*/
        var jogadorPage= new NavigationPage(new MenuJogador());
        var sorteioPage = new NavigationPage(new MenuSorteio());
        var partidaPage = new NavigationPage(new MenuPartida());

        jogadorPage.BarBackgroundColor = Colors.ForestGreen;
        jogadorPage.BarTextColor = Colors.White;
        sorteioPage.BarBackgroundColor = Colors.ForestGreen;
        sorteioPage.BarTextColor = Colors.White;
        partidaPage.BarBackgroundColor = Colors.ForestGreen;
        partidaPage.BarTextColor = Colors.White;

        /*Menu de Jogador*/
        var cadastroPage = new NavigationPage(new menuJogadorCad());
        var editarPage = new NavigationPage(new menuJogadorEditar());
        var excluirPage = new NavigationPage(new menuJogadorExcluir());
        var listarPage = new NavigationPage(new menuJogadorLista());

        cadastroPage.BarBackgroundColor = Colors.ForestGreen;
        cadastroPage.BarTextColor = Colors.White;
        editarPage.BarBackgroundColor = Colors.ForestGreen;
        editarPage.BarTextColor = Colors.White;
        excluirPage.BarBackgroundColor = Colors.ForestGreen;
        excluirPage.BarTextColor = Colors.White;
        listarPage.BarBackgroundColor = Colors.ForestGreen;
        listarPage.BarTextColor = Colors.White;

        /*Menu de Sorteio*/
        var sortearPage = new NavigationPage(new menuSorteioSort());
        var verTimesPage = new NavigationPage(new menuSorteioLista());

        sortearPage.BarBackgroundColor = Colors.ForestGreen;
        sortearPage.BarTextColor = Colors.White;
        verTimesPage.BarBackgroundColor = Colors.ForestGreen;
        verTimesPage.BarTextColor = Colors.White;

        /*Menu de Partidas*/
        var registrarPage = new NavigationPage(new menuPartidaReg());
        var historicoPage = new NavigationPage(new menuPartidaHist());
        var apagarhistPage = new NavigationPage(new menuPartidaApagHist());

        registrarPage.BarBackgroundColor = Colors.ForestGreen;
        registrarPage.BarTextColor = Colors.White;
        historicoPage.BarBackgroundColor = Colors.ForestGreen;
        historicoPage.BarTextColor = Colors.White;
        apagarhistPage.BarBackgroundColor = Colors.ForestGreen;
        apagarhistPage.BarTextColor = Colors.White;














    }
}
