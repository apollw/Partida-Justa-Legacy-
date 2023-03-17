namespace Partida_Justa;

public partial class menuPartidaReg : ContentPage
{
	public menuPartidaReg()
	{
		InitializeComponent();
	}

    ////Pode depois ser colocado no XML para resgatar a data e a hora do registro da partida
    //BindingContext="{x:Static sys:DateTime.Now}"
    //    <Label Text = "{Binding Year, StringFormat='The year is {0}'}" />
    //    < Label Text="{Binding StringFormat='The month is {0:MMMM}'}" />
    //    <Label Text = "{Binding Day, StringFormat='The day is {0}'}" />
    //    < Label Text="{Binding StringFormat='The time is {0:T}'}" />
}