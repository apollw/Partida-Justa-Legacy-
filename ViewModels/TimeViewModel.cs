using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Partida_Justa.Models
{
    public class TimeViewModel
    {

        private ModelJogador objJogador = new ModelJogador();
        private ModelTime objTime = new ModelTime();
        private ObservableCollection<ModelJogador> _jogadores;

        //OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //Comandos
        public ICommand SortearCommand { get; }


        public ModelJogador ObjJogador { get => objJogador; set => objJogador = value; }
        public ModelTime ObjTime { get => objTime; set => objTime = value; }


        public TimeViewModel()
        {
          Jogadores = new ObservableCollection<ModelJogador>();
          SortearCommand = new Command(OnSortearTime);
        }

        public string NomeJogador
        {
            get { return objJogador.Nome; }
            set
            {
                objJogador.Nome = value;
                OnPropertyChanged(nameof(NomeJogador));
            }
        }

        public int NotaJogador
        {
            get { return objJogador.Nota; }
            set
            {
                objJogador.Nota = value;
                OnPropertyChanged(nameof(NotaJogador));
            }
        }

        public ObservableCollection<ModelJogador> Jogadores
        {
            get => _jogadores;
            set
            {
                _jogadores = value;
                OnPropertyChanged(nameof(Jogadores));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //A partir da lista salva em JSON, montar um objeto Time com o número de jogadores 
        //determinado no Picker

        void OnSortearTime()
        {
            // Verifica se o arquivo jogadores.json existe
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");

            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e desserializa em uma lista de objetos JogadorModel
                string json = File.ReadAllText(filePath);
                List<ModelJogador> jogadores = new List<ModelJogador>();

                if (json != string.Empty)
                    jogadores = JsonConvert.DeserializeObject<List<ModelJogador>>(json);

                Jogadores = new ObservableCollection<ModelJogador>(jogadores);
            }

            //Após deserializar a lista de jogadores, usar essa lista para a lógica de sorteio

            ObservableCollection <ModelJogador> listaTemporaria = new ObservableCollection<ModelJogador>(Jogadores);
            int tamanhoEquipe = 2;
            int quantidadeTimes = 0;
            //string input;

            //Console.WriteLine("Qual o tamanho das equipes?");
            //input = Console.ReadLine();
            //tamanhoEquipe = int.Parse(input);
            //quantidadeTimes = Jogadores.Count() / tamanhoEquipe;
            //Console.WriteLine(quantidadeTimes);

            int k = 1;
            int j = 1;

            do
            {
                //Time timeGen = new Time();
                //timeGen = timeGen.AdicionarNovoTime();

                //Laço interno para adicionar jogadores a cada time
                do
                {
                    Random rnd = new Random();
                    int indice = rnd.Next(listaTemporaria.Count);
                    ModelJogador element = listaTemporaria[indice];
                    listaTemporaria.RemoveAt(indice); //Retira o elemento no índice   

                    ObjTime.JogadorTime[indice].NomeJogador = element.Nome;
                    ObjTime.JogadorTime[indice].NotaJogador = element.Nota;

                    k++; //Adicionou um jogador
                }
                while (k <= tamanhoEquipe);
                k = 1;//Reinicia o ciclo de adicionar jogadores    

                //Após esse processo, adicionamos o time na lista geral de times*/
                //listaTimes.Add(timeGen);
                j++;

            } while (j <= quantidadeTimes);
        }
    }
}