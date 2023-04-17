using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Produto
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ProdutoModel ProdutoModel { get; set; } = new();

        public List<CategoriaModel> CategoriaList { get; set; } = new();

        public Edit(AppDbContext context){
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

            /*##################*/
            var categoria = CategoriaList.FirstOrDefault(c => c.CategoriaId == ProdutoModel.CategoriaId);
            
            CategoriaList = await _context.Categoria!.ToListAsync();
            

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }

            var produtoToUpdate = await _context.Produto!.FindAsync(id);

            if(produtoToUpdate == null){
                return NotFound();
            }

            produtoToUpdate.Nome = ProdutoModel.Nome;
            produtoToUpdate.Descricao = ProdutoModel.Descricao;
            produtoToUpdate.Preco = ProdutoModel.Preco;
            produtoToUpdate.CategoriaId = ProdutoModel.CategoriaId;

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Produto/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}