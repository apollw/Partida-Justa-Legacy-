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

        //Não há necessidade de criar novas var para cada menu a fim de editar suas propriedades
        //Quando colocamos a NavigationPage inicial, apenas alterando a sua propriedade já
        //podemos alterar todas as propriedades dos menus subsequentes
        //Além disso, para gerar os outros menus, podemos apenas usar os métodos push ou pop
        //quando for necessário

    }
}
