using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class AtendimentoModel
    {
<<<<<<< HEAD
        [Key]
        public int AtendimentoId { get; set; }

        // [ForeignKey]
        public int MesaId { get; set; }
=======
        public int Id { get; set; }
        public int Id_Mesa { get; set; }
>>>>>>> ae83dd9d66d72d34792ab17ac7635b3421bdefe6
        public MesaModel? Mesa { get; set; }
        //public int Id_Garcon { get; set; }
        public List<GarconModel>? Garcons { get; set; } //mudei para Lista de garcons pois uma mesa pode ser atendida por varios garcons 
        public DateTime HorarioPedido { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}