using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace Partida_Justa.Models
{
    //The base of everything has to do with MVVM: INotifyPropertyChanged
    public class JogadorViewModel : INotifyPropertyChanged
    {
        //Properties
        private ModelJogador objJogador = new ModelJogador();
        private bool repeticao;
        private bool encontrado;
       
        private ObservableCollection<ModelJogador> _jogadores;
        public event PropertyChangedEventHandler PropertyChanged;

        public JogadorViewModel()
        {
            EnviarCommand = new Command(OnEnviar);
            DeleteCommand = new Command(OnExcluir);
            Jogadores = new ObservableCollection<ModelJogador>();
            
        }

        public ModelJogador ObjJogador { get => objJogador; set => objJogador = value; }
        public bool Repeticao { get => repeticao; set => repeticao = value; }
        public bool Encontrado { get => encontrado; set => encontrado = value; }

        /*Implementando Comando*/
        public ICommand EnviarCommand { get; }
        public ICommand DeleteCommand { get; }

        public string NomeJogador
        {
            get{ return objJogador.Nome; } 
            set{ objJogador.Nome = value;
                 OnPropertyChanged(nameof(NomeJogador));
            } 
        }

        public int NotaJogador
        {
            get { return objJogador.Nota; }
            set{ objJogador.Nota = value;
                OnPropertyChanged(nameof(NotaJogador));
            }
        }

        public ObservableCollection<ModelJogador> Jogadores
        {
            get => _jogadores;
            set{ _jogadores = value;
                OnPropertyChanged(nameof(Jogadores));
            }
        }

        //A method that any of our ViewModels could call to raise this
        //event, because we need to raise this event to tell .NET MAUI
        //when things are happening
        public void OnPropertyChanged(string propertyName)
        {
            //?. is doing a "null check", and what that is saying is:
            //"Is anyboy subscribed currently to this event, and if so,
            //then, invoke it"
            //It's gonna pass itself, and this is gonna give this new
            //PropertyChangedEventArgs, that's going to pass in the 
            //specific name of the property
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
              
        public void OnExcluirJogador(ModelJogador jogador)
        {
            Jogadores.Remove(jogador);

            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            File.WriteAllText(filePath, JsonConvert.SerializeObject(Jogadores));
        }


        void OnEnviar()
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

             foreach(ModelJogador element in Jogadores)
            {
                if (element.Nome.Trim() == objJogador.Nome.Trim())
                {
                    Repeticao = true;
                    break;
                }
            }

            if (objJogador.Nome != String.Empty && objJogador.Nota != 0 && Repeticao == false)
            {               
                Jogadores.Add(objJogador);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(Jogadores));                
            }

            //salva a string JSON em um arquivo no Desktop
            //var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "jogadores.json");
            //File.WriteAllText(filePath, json);
        }

        public void OnCarregar()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e desserializa em uma lista de objetos JogadorModel
                string json = File.ReadAllText(filePath);
                List<ModelJogador> jogadores = new List<ModelJogador>();

                if (json != string.Empty)
                    jogadores = JsonConvert.DeserializeObject<List<ModelJogador>>(json);

                Jogadores = new ObservableCollection<ModelJogador>(jogadores);
            }
        }

        //O método abaixo apaga não os elementos do arquivo JSON em si, mas sim todo o arquivo
        public void OnExcluir()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e apaga tudo
                File.WriteAllText(filePath, string.Empty);
            }
        }        
    }
}
