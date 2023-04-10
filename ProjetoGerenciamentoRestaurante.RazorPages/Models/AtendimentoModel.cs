using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class AtendimentoModel
    {
        [Key]
        public int AtendimentoId { get; set; }

        // [ForeignKey]
        public int MesaId { get; set; }
        public MesaModel? Mesa { get; set; }
        public int GarconId { get; set; }
        public GarconModel? Garcon { get; set; }
        public DateTime HorarioPedido { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}