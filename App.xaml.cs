namespace Partida_Justa;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        /*Página Inicial*/
        var navPage = new NavigationPage(new MainPage());
        MainPage = navPage;

        //Alterando propriedades da página
        navPage.BarBackgroundColor = Colors.ForestGreen;
        navPage.BarTextColor = Colors.White;
      
    }
}
