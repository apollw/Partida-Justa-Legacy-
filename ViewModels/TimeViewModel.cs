using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa.Models
{
    internal class TimeViewModel
    {
        //Propriedades - Encapsuladas
        private string Nome;
        private int Nivel;
        private int NumeroJog;
        private List<JogadorViewModel> JogadorTime = new List<JogadorViewModel>();

        //Set e Get de Nome
        public void SetNome(String Nome)
        { this.Nome = Nome; }
        public String GetNome()
        { return this.Nome; }

        //Set e Get de Nivel
        public void SetNivel(int Nivel)
        { this.Nivel = Nivel; }
        public int GetNivel()
        { return this.Nivel; }

        //Set e Get de NumeroJog
        public void SetNumeroJog(int NumeroJog)
        { this.NumeroJog = NumeroJog; }
        public int GetNumeroJog()
        { return this.NumeroJog; }

        //Set e Get de JogadorTime
        public void SetJogadorTime(JogadorViewModel Jogador)
        {
            this.JogadorTime.Add(Jogador); //Adiciona diretamente jogador à lista de Jogadores
        }
        public List<JogadorViewModel> GetJogadorTime()
        {
            return this.JogadorTime; //Retorna jogador da lista de Jogadores
        }

        /*
        public String GetNomeJogador(int i)
        { return this.JogadorTime[i].Nome; }

        public int GetNotaJogador(int i)
        { return this.JogadorTime[i].Nota; }*/


        //Construtores
        public TimeViewModel()
        {

        }

        public TimeViewModel AdicionarNovoTime()
        {
            Console.WriteLine("Adicione os Dados do Time");
            TimeViewModel temp = new TimeViewModel();
            string input;

            Console.WriteLine("Nome:");
            input = Console.ReadLine();
            temp.Nome = input;
            //Console.WriteLine("Nível"); //Nessa parte deveremos calcular o nível do Time com algum método
            //input = Console.ReadLine();
            //temp.Nivel = int.Parse(input);
            /*Console.WriteLine("Número de Jogadores");
            input = Console.ReadLine();
            temp.NumeroJog = int.Parse(input);*/

            return temp;// Retorna o time criado
        }

        public void CalcularNivelTime()
        {
            int nivelCalculado = 0; //Variável que vai armazenar o nível do time

            Nivel = nivelCalculado;
        }

    }
}
