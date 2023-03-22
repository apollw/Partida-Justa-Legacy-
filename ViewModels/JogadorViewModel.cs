using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        string nomeJogador; //This is private
        int notaJogador;

        private ObservableCollection<JogadorModel> _jogadores;
        public ObservableCollection<JogadorModel> Jogadores
        {
            get => _jogadores;
            set
            {
                _jogadores = value;
                OnPropertyChanged(nameof(Jogadores));
            }
        }
        public string NomeJogador
        {
            get => nomeJogador;
            set
            {
                if (nomeJogador == value)
                    return;
                nomeJogador = value;
                OnPropertyChanged(nameof(NomeJogador));
            }
        }

        public int NotaJogador
        {
            get => notaJogador;
            set
            {
                if (notaJogador == value)
                    return;
                notaJogador = value;
                OnPropertyChanged(nameof(NotaJogador));
            }
        }

        //This is the specific event the .NET MAUI is registering
        //and signing up for. This is a way of saying "hey, I've
        //changed some code in my code behind; I'm doing some data
        //binding to the User Interface (UI); .NET MAUI, please go
        //update my user interface for me"
        public event PropertyChangedEventHandler PropertyChanged;

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

        /*Fazendo a mesma coisa acima, mas usando CommunityTookit.Mvvm*/

        //Instead of inheriting and implementing INotifyPropertyChanged,
        //we can do that:

        //Primeira opção
        //[INotifyPropertyChanged]

        //public partial class JogadorViewModel
        //{
        //    public JogadorViewModel()
        //    {
              
        //    }
        //    string nomeJogador;
        //}


        //Segunda opção
        //public partial class JogadorViewModel : ObservableObject
        ////Inheriting from this base class will automatically implement
        ////INotifyPropertyChanged, and additionally, INotifyPropertyChanging
        //{
        //    public JogadorViewModel() 
        //    {
                
        //    }
        //    //Uma ObservableProperty para cada Property
        //    [ObservableProperty]
        //    string nomeJogador;

        //    [ObservableObject]
        //    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        //    bool isBusy;
        //}

        /*Implementando Comando*/
        public ICommand EnviarCommand { get;}

        public JogadorViewModel()
        {
            EnviarCommand = new Command(OnEnviar);
            Jogadores = new ObservableCollection<JogadorModel>();
        }

        void OnEnviar()
        {

            // Verifica se o arquivo jogadores.json existe
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            if (File.Exists(filePath))
            {
                // Se o arquivo existe, lê o conteúdo do arquivo e desserializa em uma lista de objetos JogadorModel
                string json1 = File.ReadAllText(filePath);
                List<JogadorModel> jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(json1);
                Jogadores = new ObservableCollection<JogadorModel>(jogadores);
            }

            // Cria uma nova instância da classe Jogador com os dados de entrada do usuário
            var jogador = new JogadorModel { Nome = NomeJogador , Nota = NotaJogador};

            // Adiciona o jogador à lista de jogadores
            Jogadores.Add(jogador);

            // Limpa a propriedade NomeJogador para que o usuário possa inserir um novo nome
            NomeJogador = string.Empty;

            // Serializa a lista de jogadores em uma string JSON
            var json2 = JsonConvert.SerializeObject(Jogadores);

            // Salva a string JSON em um arquivo local
            File.WriteAllText(filePath, json2);

            //Salva a string JSON em um arquivo local
            var filePath2 = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            File.WriteAllText(filePath, json2);

            //salva a string JSON em um arquivo no Desktop
            //var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "jogadores.json");
            //File.WriteAllText(filePath, json);
        }

        public void OnCarregar()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json"); 
            string json = File.ReadAllText(filePath);
            List<JogadorModel> jogadores = JsonConvert.DeserializeObject<List<JogadorModel>>(json);
            Jogadores = new ObservableCollection<JogadorModel>(jogadores);
        }

    }
}
