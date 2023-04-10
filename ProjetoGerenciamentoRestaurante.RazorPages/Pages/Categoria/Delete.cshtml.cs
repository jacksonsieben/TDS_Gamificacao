using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Categoria
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]

            public CategoriaModel CategoriaModel { get; set; } = new();
            public Delete(AppDbContext context){
                _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Categoria == null){
                return NotFound();
            }

            var categoriaModel = await _context.Categoria.FirstOrDefaultAsync(e => e.CategoriaId == id);
            if(categoriaModel == null){
                return NotFound();
            }
            CategoriaModel = categoriaModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            var categoriaToDelete = await _context.Categoria!.FindAsync(id);

            if(categoriaToDelete == null){
                return NotFound();
            }

            try{
                _context.Categoria.Remove(categoriaToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Categoria/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}