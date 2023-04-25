using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Partida_Justa
{
    public class ModelJogador 
    {
        private string nome = string.Empty;
        private int nota = 1;
        private bool presente = false;

        public string Nome { get => nome; set => nome = value; }
        public int Nota { get => nota; set => nota = value; }
        public bool Presente { get => presente; set => presente = value; }
    }
}
