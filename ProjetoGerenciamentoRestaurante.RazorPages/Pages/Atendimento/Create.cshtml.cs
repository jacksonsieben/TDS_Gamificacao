using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Create : PageModel
    {
         private readonly AppDbContext _context;
        [BindProperty]
        public AtendimentoModel AtendimentoModel { get; set; } = new();
        public List<MesaModel> MesaList { get; set; } = new();
        public Create(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            MesaList = await _context.Mesa!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }

            try{
                bool mesaOcupada = await _context.Mesa!.AnyAsync(m => m.MesaId == AtendimentoModel.MesaId && m.Status);
                if (mesaOcupada) {
                    ModelState.AddModelError(string.Empty, "A mesa já está ocupada!");
                    return Page();
                }

                _context.Add(AtendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
            } catch(DbUpdateException){
                return Page();
            }
            
        }
    }
}