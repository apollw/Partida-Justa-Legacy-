using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa.Models
{
    internal class MainViewModel
    {
        //    static void Main(string[] args)
        //    {
        //        List<JogadorViewModel> listaGeral = new List<JogadorViewModel>(); //Lista geral de todos os jogadores
        //        List<TimeViewModel> listaTimes = new List<TimeViewModel>(); //Lista geral de todos os times

        //        /*A ideia é adicionar, sempre que eu quiser, novos jogadores à uma lista geral de jogadores.
        //        A partir dessa lista, devo ser capaz de sortear jogadores baseados no critério "Nota", para montar 
        //        os times de forma balanceada, e sem que haja uma distância muito grande de um time pro outro.             
        //        Cada jogador possui a propriedade "Nota", que servirá para colocá-los numa pool para o sorteio.            
        //        O sorteio dos jogadores gera automaticamente os times, objetos do tipo Time que poderão ser
        //        manipulados de qualquer maneira*/

        //        /*-----------------------Função para Adicionar à Lista Geral---------------------------*/
        //        JogadorViewModel generico = new JogadorViewModel();
        //        for (int i = 0; i < 13; i++)
        //        {
        //            generico = generico.AdicionarNovoJogador(); //Recebe um jogador temp criado
        //            listaGeral.Add(generico); //Adiciona novo jogador à lista geral
        //        }
        //        /*------------------------------------------------------------------------------------*/

        //        /*-----------------------Função para Imprimir a Lista Geral---------------------------*/
        //        foreach (JogadorViewModel element in listaGeral)
        //        {
        //            Console.WriteLine("");
        //            Console.WriteLine("DADOS DO JOGADOR");
        //            Console.WriteLine("Nome: " + element.GetNome());
        //            Console.WriteLine("Nota: " + element.GetNota());
        //            Console.WriteLine("");
        //        }
        //        /*------------------------------------------------------------------------------------*/

        //        /*-------------Distribuir aleatoriamente os jogadores da Lista Geral nos times-------*/
        //        List<JogadorViewModel> listaTemporaria = new List<JogadorViewModel>(listaGeral);
        //        int tamanhoEquipe = 0;
        //        int quantidadeTimes = 0;
        //        string input;

        //        Console.WriteLine("Qual o tamanho das equipes?");
        //        input = Console.ReadLine();
        //        tamanhoEquipe = int.Parse(input);
        //        quantidadeTimes = listaGeral.Count() / tamanhoEquipe;
        //        Console.WriteLine(quantidadeTimes);

        //        int k = 1;
        //        int j = 1;

        //        do
        //        {
        //            TimeViewModel timeGen = new TimeViewModel();
        //            timeGen = timeGen.AdicionarNovoTime();
        //            //Laço interno para adicionar jogadores a cada time
        //            do
        //            {
        //                Random rnd = new Random();
        //                int indice = rnd.Next(listaTemporaria.Count);
        //                JogadorViewModel element = listaTemporaria[indice];
        //                listaTemporaria.RemoveAt(indice); //Retira o elemento no índice   
        //                timeGen.SetJogadorTime(element); //Insere o Jogador na Lista
        //                Console.WriteLine("Jogador adicionado: " + element.GetNome());
        //                k++;//Adicionou um jogador
        //            }
        //            while (k <= tamanhoEquipe);
        //            k = 1;//Reinicia o ciclo de adicionar jogadores    

        //            //Após esse processo, adicionamos o time na lista geral de times*/
        //            listaTimes.Add(timeGen);
        //            j++;
        //            //Imprimir estado da lista Temporaria no momento
        //            Console.WriteLine("Quantidades de Membros na Lista Temporária: " + listaTemporaria.Count());

        //        } while (j <= quantidadeTimes);
        //        j = 1;

        //        //Função de Balanceamento
        //        //Primeiro pegamos as médias de cada time. Depois calculamos a diferença da maior média para a menor média
        //        //Quanto menor for essa diferença, mais balanceados estarão os times

        //        //Método 1 para varrer todos os times da lista de times
        //        for (int i = 0; i < quantidadeTimes; i++)
        //        {
        //            Console.WriteLine("DADOS DO TIME");
        //            Console.Write("Nome: " + listaTimes[i].GetNome());
        //            Console.WriteLine("");
        //            Console.WriteLine("Número de Times Cadastrados: " + listaTimes.Count());
        //            Console.WriteLine("Nome dos Jogadores");

        //            //
        //        }
        //        //FIM
        //    }
        //}
    }
}

