namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class PedidoView
    {
        public MesaModel? Mesa { get; set; }
        public GarconModel? Garcon { get; set; }
        public AtendimentoModel? Atendimento { get; set; }
        public double totalVendas = 0;
        public int countPedidos = 0;
        public double quantidadeTotal = 0;
    }
}