using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Produto
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<ProdutoModel> ProdutoList { get; set; } = new();
        public Index(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            ProdutoList = await _context.Produto!.ToListAsync();
            return Page();
        }
    }
}