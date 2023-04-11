using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Mesa
{
    public class Add : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]

            public MesaModel MesaModel { get; set; } = new();
            public Add(AppDbContext context){
                _context = context;
        }
        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }

            if (MesaModel != null) _context.Mesa!.Add(MesaModel);

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Mesa/Index");
            } catch(DbUpdateException){
                return Page();
            }
        }
    }
}