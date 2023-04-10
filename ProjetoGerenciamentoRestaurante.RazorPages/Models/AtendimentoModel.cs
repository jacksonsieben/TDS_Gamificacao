namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class AtendimentoModel
    {
        public int Id { get; set; }
        public int Id_Mesa { get; set; }
        public MesaModel? Mesa { get; set; }
        public int Id_Garcon { get; set; }
        public GarconModel? Garcon { get; set; }
        public DateTime HorarioPedido { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}