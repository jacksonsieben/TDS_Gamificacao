using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        // public AtendimentoModel AtendimentoModel { get; set; } = new();
        
        public List<Pedido_ProdutoModel> Pedido_ProdutoList { get; set; } = new();
        
        public Details(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Pedido_Produto == null){
                return NotFound();
            }

            var pedido_ProdutoList = await _context.Pedido_Produto
            .Include(p => p.Pedido)
                .ThenInclude(p => p.Garcon)
            .Include(p => p.Pedido)
                .ThenInclude(p => p.Atendimento)
                    .ThenInclude(a => a.Mesa)
            .Include(p => p.Produto)
            .Where(e => e.Pedido.Atendimento.AtendimentoId == id)
            // .FirstOrDefaultAsync(e => e.PedidoProdutoId == id)
            .ToListAsync();


            if(pedido_ProdutoList == null){
                return NotFound();
            }
            Pedido_ProdutoList = pedido_ProdutoList;

            return Page();
        }
    }
}