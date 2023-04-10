using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade1.RazorPages.Model
{
    public class Produto
    {
        private string nome;
        private string descricao;
        private decimal preco;
        private Categoria categoria;

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

        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
    }
}