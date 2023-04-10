using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Produto
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public ProdutoModel ProdutoModel { get; set; } = new();

        public Details(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Produto == null){
                return NotFound();
            }

            var produtoModel = await _context.Produto
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(e => e.ProdutoId == id);

            if(produtoModel == null){
                return NotFound();
            }
            ProdutoModel = produtoModel;
            return Page();
        }
    }
}