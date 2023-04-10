namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class AtendimentoModel
    {
        public int AtendimentoId { get; set; }
        public int MesaId { get; set; }
        public MesaModel? Mesa { get; set; }
        public int GarconId { get; set; }
        public GarconModel? Garcon { get; set; }
        public DateTime HorarioPedido { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}