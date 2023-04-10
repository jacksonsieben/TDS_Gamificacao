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

            public GarconModel GarconModel { get; set; } = new();
            public Edit(AppDbContext context){
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
            if(!ModelState.IsValid){
                return Page();
            }

            var garconToUpdate = await _context.Garcon!.FindAsync(id);

            if(garconToUpdate == null){
                return NotFound();
            }

            garconToUpdate.Nome = GarconModel.Nome;
            garconToUpdate.Sobrenome = GarconModel.Sobrenome;
            garconToUpdate.Cpf = GarconModel.Cpf;
            garconToUpdate.Telefone = GarconModel.Telefone;

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Garcon/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}