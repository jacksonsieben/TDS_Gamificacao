using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class ProdutoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório!")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório!")]
        public double Preco { get; set; }
        
        [Required(ErrorMessage = "Categoria é obrigatória!")]
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }
    }
}