using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade1.RazorPages.Model
{
    public class Categoria
    {
            private string nome;
        private string descricao;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}