namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class MesaModel
    {
        public int MesaId { get; set; }
        public int Numero { get; set; }
        public bool Ocupada { get; set; }
        public DateTime? HoraAbertura { get; set; }
    }
}