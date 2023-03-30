using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa.Models
{
    public class ModelTime
    {
        string nomeTime;
        int nivelTime;
        int numeroJog;
        List<JogadorViewModel> jogadorTime = new List<JogadorViewModel>();

        public string NomeTime { get => nomeTime; set => nomeTime = value; }
        public int NivelTime { get => nivelTime; set => nivelTime = value; }
        public int NumeroJog { get => numeroJog; set => numeroJog = value; }
        public List<JogadorViewModel> JogadorTime { get => jogadorTime; set => jogadorTime = value; }
    }
}
