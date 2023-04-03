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

        public void OnPropertyChanged(string propertyName)
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //A partir da lista salva em JSON, montar um objeto Time com o número de jogadores 
        //determinado no Picker
        public int tamanhoEquipe;
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

                if (json != string.Empty)
                    jogadores = JsonConvert.DeserializeObject<List<ModelJogador>>(json);

                Jogadores = new ObservableCollection<ModelJogador>(jogadores);
            }

            //Após deserializar a lista de jogadores, usar essa lista para a lógica de sorteio
            ObservableCollection <ModelJogador> listaTemporaria = new ObservableCollection<ModelJogador>(Jogadores);
            //Inicializa também a lista geral de times (Times)
            ObservableCollection <ModelTime> Times = new ObservableCollection<ModelTime>();           
                     
            //Resgata o valor do picker e calcula a quantidade de times a ser gerada
            quantidadeTimes = Jogadores.Count / tamanhoEquipe;        

            //Embaralhar a ordem dos elementos da lista temporária para
            //gerar resultados distintos na hora de gerar times com mesmo tamanho

            /*O que ocorre é que, ao tentar sortear times diferentes de tamanhos iguais,
             a lista temp sempre copiava a lista original na mesma ordem, então, o último 
            jogador da lista para times diferentes sempre ficava de fora*/

            //Apenas gera times se houver jogadores suficientes para gerá-los
            if(quantidadeTimes> 0)
            {
                int k = 1;
                int j = 1;

                do
                {
                    ModelTime timeGen = new ModelTime();
                    //timeGen = timeGen.AdicionarNovoTime();

                    //Inicializa a propriedade JogadorTime pela quantidade de jogadores fornecida
                    timeGen.JogadorTime = new ObservableCollection<JogadorViewModel>();
                    for (int i = 0; i < tamanhoEquipe; i++)
                    {
                        JogadorViewModel jogador = new JogadorViewModel();
                        jogador.NomeJogador = string.Empty;
                        jogador.NotaJogador = 0;
                        timeGen.JogadorTime.Add(jogador);
                    }

                    //Após a ObservableCollection dentro da classe ModelTime ter sido inicializada
                    //agora inserimos os jogadores a cada time                

                    //Laço interno para adicionar jogadores a cada time
                    //Aqui contém a lógica de sorteio dos times             

                    do
                    {
                        Random rnd = new Random();
                        int indice = rnd.Next(listaTemporaria.Count - 1);
                        ModelJogador element = listaTemporaria[indice];

                        listaTemporaria.RemoveAt(indice); //Retira o elemento (Jogador) no índice 

                        //Aqui parece que a JogadorTime não tem nenhum elemento para ser copiado em cima
                        //Então é necessário inicializá-la fora do loop
                        timeGen.JogadorTime[k - 1].NomeJogador = element.Nome;
                        timeGen.JogadorTime[k - 1].NotaJogador = element.Nota;

                        k++; //Adicionou um jogador
                    }
                    while (k <= tamanhoEquipe);
                    k = 1;//Reinicia o ciclo de adicionar jogadores    

                    //Após esse processo, adicionamos o time na lista geral de times
                    //A lista geral de times aqui é uma ObservableCollection
                    Times.Add(timeGen);
                    //listaTimes.Add(timeGen);
                    j++;
                } while (j <= quantidadeTimes);
                Criado = true; //Times criados

                //Criar lista de espera com os jogadores que sobraram                

                // Serializa a coleção Times em uma string JSON
                string json2 = JsonConvert.SerializeObject(Times);

                ////salva a string JSON em um arquivo no Desktop
                //var filePath2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "times.json");
                //File.WriteAllText(filePath2, json2);

                // Salva a string JSON em um arquivo
                string filePath2 = Path.Combine(FileSystem.AppDataDirectory, "times.json");
                File.WriteAllText(filePath2, json2);
            }
            else
                Criado=false;
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

            OnPropertyChanged(nameof(Times));

        }

    }
}