using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa.Models
{
    public class JogadorViewModel : INotifyPropertyChanged
    {

        //Propriedades
        private string Nome;
        private int Nota;

        //Variável de Teste da PropertyChanged
        string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            } 
        }

        //Esse evento significa que podemos notificar o .NET MAUI
        //quando nós quisermos atualizar a interface do usuário
        public event PropertyChangedEventHandler PropertyChanged;

        //public int Index { get; set; }

        //Set e Get de Nome
        public void SetNome(String Nome)
        { this.Nome = Nome; }
        public String GetNome()
        { return this.Nome; }

        //Set e Get de Nivel
        public void SetNota(int Nota)
        { this.Nota = Nota; }
        public int GetNota()
        { return this.Nota; }

        //Construtores default
        public JogadorViewModel()
        {
        }

        void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));

        public JogadorViewModel AdicionarNovoJogador()
        {
            Console.WriteLine("Adicione jogadores ao Banco de Jogadores");
            //Registrar Todas as Informações de um Jogador
            //Precisa instanciar um objeto de Jogador para então este poder ser adicionado à Lista

            JogadorViewModel temp = new JogadorViewModel();
            string input;

            Console.Write("Nome:");
            input = Console.ReadLine();
            temp.Nome = input;
            //Console.WriteLine("Posição");
            //input = Console.ReadLine();
            //temp.Posicao = input;
            Console.Write("Nota:");
            input = Console.ReadLine();
            temp.Nota = int.Parse(input);

            return temp;// Retorna o jogador criado
        }
    }        
 }



