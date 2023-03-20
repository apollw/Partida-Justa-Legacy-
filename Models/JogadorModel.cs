using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa
{
    public class JogadorModel
    {
        ////Propriedades
        public string Nome { get; set; }
        public int Nota { get; set; }  

    }
}


//Propriedades
//private string Nome;
//private int Nota;

//Set e Get de Nome
//public void SetNome(string Nome)
//{ this.Nome = Nome; }
//public string GetNome()
//{ return Nome; }

//Set e Get de Nivel
//public void SetNota(int Nota)
//{ this.Nota = Nota; }
//public int GetNota()
//{ return Nota; }

/*Talvez esse método abaixo possa ser útil para a inclusão de jogadores*/

//public JogadorModel AdicionarNovoJogador()
//{
//    //Console.WriteLine("Adicione jogadores ao Banco de Jogadores");
//    //Registrar Todas as Informações de um Jogador
//    //Precisa instanciar um objeto de Jogador para então este poder ser adicionado à Lista

//    JogadorModel temp = new JogadorModel();
//    string input;

//    Console.Write("Nome:");
//    input = Console.ReadLine();
//    temp.Nome = input;

//    //Console.Write("Nota:");
//    input = Console.ReadLine();
//    temp.Nota = int.Parse(input);

//    return temp;// Retorna o jogador criado
//}
