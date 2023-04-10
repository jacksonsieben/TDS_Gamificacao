using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class AtendimentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtendimentoId { get; set; }

        [ForeignKey("Mesa")]
        public int MesaId { get; set; }
        public MesaModel? Mesa { get; set; }
        //public int Id_Garcon { get; set; }
        public List<GarconModel>? Garcons { get; set; } //mudei para Lista de garcons pois uma mesa pode ser atendida por varios garcons 
        public DateTime HorarioPedido { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}