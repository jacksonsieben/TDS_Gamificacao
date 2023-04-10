using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade1.RazorPages.Model
{
    public class Atendimento
    {
        private Mesa mesa;
        private Garcom garcom;
        private DateTime horario;
        private List<Produto> produtos;

        public Mesa Mesa
        {
            get { return mesa; }
            set { mesa = value; }
        }

        public Garcom Garcom
        {
            get { return garcom; }
            set { garcom = value; }
        }

        public DateTime Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public List<Produto> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }
    }
}