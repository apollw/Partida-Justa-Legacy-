using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Partida_Justa.Models
{
    public class TimeViewModel
    {
        private ModelJogador objJogador = new ModelJogador(); //Jogador modelo para inclusão
        private ModelTime objTime = new ModelTime(); //Time modelo para inclusão
        private bool criado; //Confirmação de times criados

        private ObservableCollection<ModelJogador> _jogadores;
        private ObservableCollection<ModelJogador> _jogadoresPresentes;
        private ObservableCollection<ModelTime> _times;

        //OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //Comandos
        public ICommand SortearCommand { get; }

        //Propriedades

        public ModelJogador ObjJogador { get => objJogador; set => objJogador = value; }
        public ModelTime ObjTime { get => objTime; set => objTime = value; }
        public bool Criado { get => criado; set => criado = value; }

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
        public ObservableCollection<ModelTime> Times
        {
            get => _times; 
            set
            {
                _times = value;
                OnPropertyChanged(nameof(Times));
            }
        }

        public ObservableCollection<ModelJogador> JogadoresPresentes
        {
            get => _jogadoresPresentes;
            set
            {
                _jogadoresPresentes = value;
                OnPropertyChanged(nameof(_jogadoresPresentes));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //A partir da lista salva em JSON, montar um objeto Time com o número de jogadores 
        //determinado no Picker
        public int tamanhoEquipe=2;
        int quantidadeTimes = 0;

        public void OnSortearTime()
        {
            // Verifica se o arquivo jogadores.json existe
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e desserializa em uma lista de objetos JogadorModel
                string json = File.ReadAllText(filePath);
                List<ModelJogador> jogadores = new List<ModelJogador>();
                List<ModelJogador> jogadoresPresentes = new List<ModelJogador>();

                if (json != string.Empty)
                {
                    jogadores = JsonConvert.DeserializeObject<List<ModelJogador>>(json);
                    //jogadores = jogadores.Where(j => j.Presente).ToList();
                    jogadoresPresentes = jogadores.Where(j => j.Presente).ToList();
                }

                Jogadores = new ObservableCollection<ModelJogador>(jogadores);
                JogadoresPresentes = new ObservableCollection<ModelJogador>(jogadoresPresentes);
            }
           
            //Após deserializar a lista de jogadores, usar essa lista para a lógica de sorteio
            //ObservableCollection<ModelJogador> listaTemporaria = new ObservableCollection<ModelJogador>(Jogadores);
            ObservableCollection<ModelJogador> listaTemporaria = new ObservableCollection<ModelJogador>(JogadoresPresentes);
            //Inicializa também a lista geral de times (Times)
            ObservableCollection<ModelTime> Times = new ObservableCollection<ModelTime>();

            //Embaralhar listaTemporaria
            Random rng = new Random();
            listaTemporaria = new ObservableCollection<ModelJogador>(listaTemporaria.OrderBy(x => rng.Next()));

            //Resgata o valor do picker e calcula a quantidade de times a ser gerada
            if(tamanhoEquipe != 0)
                //quantidadeTimes = Jogadores.Count / tamanhoEquipe;
                quantidadeTimes = JogadoresPresentes.Count / tamanhoEquipe; //Sorteio agora é feito com base nos presentes


                if (quantidadeTimes >= 1)
            {
                int k = 1;
                int j = 1;

                do
                {
                    ModelTime timeGen = new ModelTime();

                    //Inicializa a propriedade JogadorTime pela quantidade de jogadores fornecida
                    timeGen.JogadorTime = new ObservableCollection<JogadorViewModel>();
                    for (int i = 0; i < tamanhoEquipe; i++)
                    {
                        JogadorViewModel jogador = new JogadorViewModel();
                        jogador.NomeJogador = string.Empty;
                        jogador.NotaJogador = 0;
                        timeGen.JogadorTime.Add(jogador);
                    }

                    //Laço interno para adicionar jogadores a cada time
                    do
                    {
                        Random rnd = new Random();
                        int indice = rnd.Next(listaTemporaria.Count - 1);
                        ModelJogador element = listaTemporaria[indice];

                        listaTemporaria.RemoveAt(indice);

                        timeGen.JogadorTime[k - 1].NomeJogador = element.Nome;
                        timeGen.JogadorTime[k - 1].NotaJogador = element.Nota;

                        k++; //Adicionou um jogador
                    }
                    while (k <= tamanhoEquipe);
                    k = 1;//Reinicia o ciclo de adicionar jogadores

                    timeGen.NomeTime = "Time " + j;

                    //Após esse processo, adicionamos o time na lista geral de times
                    //A lista geral de times aqui é uma ObservableCollection
                    Times.Add(timeGen);
                    //listaTimes.Add(timeGen);
                    j++;
                } while (j <= quantidadeTimes);
                Criado = true; //Times criados

                //Criar lista de espera com os jogadores que sobraram                                            
                if (listaTemporaria.Count != 0)
                {
                    ModelTime timeEspera = new ModelTime();
                    timeEspera.JogadorTime = new ObservableCollection<JogadorViewModel>();
                    for (int i = 0; i < listaTemporaria.Count; i++)
                    {
                        JogadorViewModel jogador = new JogadorViewModel();
                        jogador.NomeJogador = string.Empty;
                        jogador.NotaJogador = 0;
                        timeEspera.JogadorTime.Add(jogador);
                    }

                    do
                    {
                        Random rnd = new Random();
                        int indice = rnd.Next(listaTemporaria.Count - 1);
                        ModelJogador element = listaTemporaria[indice];

                        listaTemporaria.RemoveAt(indice);

                        timeEspera.JogadorTime[k - 1].NomeJogador = element.Nome;
                        timeEspera.JogadorTime[k - 1].NotaJogador = element.Nota;

                        k++; //Adicionou um jogador

                    }
                    while (listaTemporaria.Count != 0);

                    timeEspera.NomeTime = "Lista de Espera";
                    Times.Add(timeEspera);
                }

                // Serializa a coleção Times em uma string JSON
                string json2 = JsonConvert.SerializeObject(Times);

                // Salva a string JSON em um arquivo
                string filePath2 = Path.Combine(FileSystem.AppDataDirectory, "times.json");
                File.WriteAllText(filePath2, json2);
            }
            else
                Criado = false;

            //Após salvar os times, atualiza o status de presença de todos os jogadores
            foreach (var jogador in Jogadores)
            {
                // Marcar ou desmarcar o jogador como presente
                jogador.Presente = false;

                // Salvar as informações atualizadas no arquivo JSON
                var filePathJogador = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
                string json = JsonConvert.SerializeObject(Jogadores);
                File.WriteAllText(filePathJogador, json);
            }
        }

        public void OnCarregarTimes()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "times.json");
            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e desserializa em uma lista de objetos ModelTime
                string json = File.ReadAllText(filePath);
                List<ModelTime> times = new List<ModelTime>();

                if (json != string.Empty)
                    times = JsonConvert.DeserializeObject<List<ModelTime>>(json);

                Times = new ObservableCollection<ModelTime>(times);
            }           
        }

    }
}