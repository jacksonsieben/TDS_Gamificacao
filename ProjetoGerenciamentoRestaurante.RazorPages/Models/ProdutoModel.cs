namespace ProjetoGerenciamentoRestaurante.RazorPages.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Id_Categoria { get; set; }
        public CategoriaModel? Categoria { get; set; }
    }
}