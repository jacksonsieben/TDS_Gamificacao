using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class GarconModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GarconId { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório!")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? Cpf { get; set; }

         [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? Telefone { get; set; }
    }
}