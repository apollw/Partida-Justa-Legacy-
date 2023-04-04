using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa.Models
{
    public class ModelPartida
    {
        private int id;
        private DateTime date;
        private int placar1;
        private int placar2;
        private string time1;
        private string time2;
        private ObservableCollection<JogadorViewModel> jogadoresPartida;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Placar1 { get => placar1; set => placar1 = value; }
        public int Placar2 { get => placar2; set => placar2 = value; }
        public string Time1 { get => time1; set => time1 = value; }
        public string Time2 { get => time2; set => time2 = value; }
        public ObservableCollection<JogadorViewModel> JogadoresPartida { get => jogadoresPartida; set => jogadoresPartida = value; }
    }
}
