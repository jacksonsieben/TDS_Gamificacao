using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Produto
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ProdutoModel ProdutoModel { get; set; } = new();
        public List<CategoriaModel> CategoriaList { get; set; } = new();

        public Create(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            var categoria = CategoriaList.FirstOrDefault(c => c.CategoriaId == 1);
            CategoriaList = await _context.Categoria!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }
            try{
                _context.Add(ProdutoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Produto/Index");
            } catch(DbUpdateException){
                return Page();
            }
        }
    }
}