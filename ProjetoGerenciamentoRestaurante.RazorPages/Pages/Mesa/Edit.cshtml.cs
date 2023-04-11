using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Mesa
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]

            public MesaModel MesaModel { get; set; } = new();
            public Edit(AppDbContext context){
                _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Mesa == null){
                return NotFound();
            }

            var mesaModel = await _context.Mesa.FirstOrDefaultAsync(e => e.MesaId == id);
            if(mesaModel == null){
                return NotFound();
            }
            MesaModel = mesaModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }
            
            var mesaToUpdate = await _context.Mesa!.FindAsync(id);

            if(mesaToUpdate == null){
                return NotFound();
            }

            mesaToUpdate.Numero = MesaModel.Numero;
            mesaToUpdate.Status = MesaModel.Status;
            if(MesaModel.Status){
                mesaToUpdate.HoraAbertura = MesaModel.HoraAbertura;
            }
            else{
                mesaToUpdate.HoraAbertura = null;
            }

            try{
                if(MesaModel.Status && MesaModel.HoraAbertura is null){
                    ModelState.AddModelError(string.Empty, "Insira uma data e hora para a abertura da mesa.");
                    return Page();
                }
                else{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Mesa/Index");
                }
            } catch(DbUpdateException){
                return Page();
            }
            
            
        }
    }
}