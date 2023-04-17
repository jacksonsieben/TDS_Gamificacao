using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Garcon
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]

            public GarconModel GarconModel { get; set; } = new();
            public Delete(AppDbContext context){
                _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Garcon == null){
                return NotFound();
            }

            var garconModel = await _context.Garcon.FirstOrDefaultAsync(e => e.GarconId == id);
            if(garconModel == null){
                return NotFound();
            }
            GarconModel = garconModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            var garconToDelete = await _context.Garcon!.FindAsync(id);

            if(garconToDelete == null){
                return NotFound();
            }

            try{
                _context.Garcon.Remove(garconToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Garcon/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}