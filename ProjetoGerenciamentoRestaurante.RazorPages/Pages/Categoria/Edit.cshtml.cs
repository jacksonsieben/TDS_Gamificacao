using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Categoria
{
    public class Edit : PageModel
    {
         private readonly AppDbContext _context;
        [BindProperty]

            public CategoriaModel CategoriaModel { get; set; } = new();
            public Edit(AppDbContext context){
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
            if(!ModelState.IsValid){
                return Page();
            }

            var categoriaToUpdate = await _context.Categoria!.FindAsync(id);

            if(categoriaToUpdate == null){
                return NotFound();
            }

            categoriaToUpdate.Nome = CategoriaModel.Nome;
            categoriaToUpdate.Descricao = CategoriaModel.Descricao;

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Categoria/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}