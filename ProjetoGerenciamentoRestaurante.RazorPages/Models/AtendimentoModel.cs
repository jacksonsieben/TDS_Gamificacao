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
    }
}