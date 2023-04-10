using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class GarconModel
    {
<<<<<<< HEAD
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GarconId { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório!")]
=======
        public int Id { get; set; }
>>>>>>> ae83dd9d66d72d34792ab17ac7635b3421bdefe6
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório!")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? Cpf { get; set; }

         [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? Telefone { get; set; }
    }
}