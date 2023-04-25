using Newtonsoft.Json;
using Partida_Justa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Partida_Justa.ViewModels
{
    public class PartidaViewModel
    {
        private ModelPartida objPartida = new ModelPartida(); //Partida modelo

        //Algumas ObservableCollection que podem ser úteis
        private ObservableCollection<ModelJogador> _jogadores;
        private ObservableCollection<ModelTime> _times;

        //OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;     

        public PartidaViewModel()
        {
            Jogadores = new ObservableCollection<ModelJogador>();
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

        public void OnCarregarTimesFormados()
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
