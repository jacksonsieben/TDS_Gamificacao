using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade1.RazorPages.Model
{
    public class Garcom
    {
        private string nome;
        private string sobrenome;
        private int id;
        private string telefone;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
    }
}