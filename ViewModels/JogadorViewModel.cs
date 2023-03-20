using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using Formatting = System.Xml.Formatting;

namespace Partida_Justa.Models{

    public class JogadorViewModel : INotifyPropertyChanged
    {
        //Propriedade que armazena os dados do jogador
        public JogadorModel Jogador { get; set; }
        //Cria uma propriedade Json do tipo string
        public string Json { get; set; }
        //Propriedade SalvarNomeCommand do tipo Command<string>
        public Command<string> SalvarNomeCommand { get; set; }


        //Construtor que recebe um objeto JogadorModel como parâmetro
        public JogadorViewModel(JogadorModel jogador)
        {
            //Atribui o objeto recebido à propriedade Jogador
            this.Jogador = jogador;

            //Inicializa a propriedade SalvarNomeCommand com uma função anônima que recebe um valor string como parâmetro
            this.SalvarNomeCommand = new Command<string>((valor) =>
            {
                //Atribui o valor recebido à propriedade Nome do objeto Jogador
                this.Jogador.Nome = valor;

                //Notifica o .NET MAUI que a propriedade Nome mudou de valor
                OnPropertyChanged(nameof(this.Jogador.Nome));
            });
        }

        //Método que notifica o .NET MAUI quando alguma propriedade mudar de valor
        private void OnPropertyChanged(string propertyName)
        {
        //Se o evento PropertyChanged não for nulo, dispara ele passando o nome da propriedade
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Esse evento significa que podemos notificar o .NET MAUI
        //quando nós quisermos atualizar a interface do usuário
        public event PropertyChangedEventHandler PropertyChanged;

    }

}






