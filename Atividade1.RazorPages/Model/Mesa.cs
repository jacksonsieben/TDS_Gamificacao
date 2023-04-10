using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade1.RazorPages.Model
{
    public class Mesa
    {
        private int numero;
        private bool ocupada;
        private DateTime? horaAbertura;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public bool Ocupada
        {
            get { return ocupada; }
            set { ocupada = value; }
        }

        public DateTime? HoraAbertura
        {
            get { return horaAbertura; }
            set { horaAbertura = value; }
        }
    }
}