using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class PedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }

        [ForeignKey("Atendimento")]
        public int AtendimentoId { get; set; }
        public AtendimentoModel? Atendimento { get; set; }

        [ForeignKey("Garcon")]
        public int GarconId { get; set; }
        public GarconModel? Garcon { get; set; }
        
        public DateTime HorarioPedido { get; set; }
    }
}