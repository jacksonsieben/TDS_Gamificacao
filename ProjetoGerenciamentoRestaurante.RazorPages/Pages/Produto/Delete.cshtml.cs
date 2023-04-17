using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Produto
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]

            public ProdutoModel ProdutoModel { get; set; } = new();
            public Delete(AppDbContext context){
                _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Produto == null){
                return NotFound();
            }

            var produtoModel = await _context.Produto.FirstOrDefaultAsync(e => e.ProdutoId == id);
            if(produtoModel == null){
                return NotFound();
            }
            ProdutoModel = produtoModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            var produtoToDelete = await _context.Produto!.FindAsync(id);

            if(produtoToDelete == null){
                return NotFound();
            }

            try{
                _context.Produto.Remove(produtoToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Produto/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}