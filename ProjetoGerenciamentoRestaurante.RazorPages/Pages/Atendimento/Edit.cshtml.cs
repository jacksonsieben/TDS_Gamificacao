using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Edit : PageModel
    {
         private readonly AppDbContext _context;
        [BindProperty]
        public AtendimentoModel AtendimentoModel { get; set; } = new();
        public MesaModel MesaModel { get; set; } = new();
        public List<MesaModel> MesaList { get; set; } = new();
        public Edit(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Atendimento == null){
                return NotFound();
            }

            var atendimentoModel = await _context.Atendimento
            .Include(p => p.Mesa)
            .FirstOrDefaultAsync(e => e.AtendimentoId == id);

            if(atendimentoModel == null){
                return NotFound();
            }
            AtendimentoModel = atendimentoModel;

            var mesa = MesaList.FirstOrDefault(c => c.MesaId == AtendimentoModel.MesaId);
            
            MesaList = await _context.Mesa!.ToListAsync();
            

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }
            var atendimentoToUpdate = await _context.Atendimento!.FindAsync(id);

            if(atendimentoToUpdate == null){
                return NotFound();
            }
            
            var mesaAntigaId = atendimentoToUpdate.MesaId;

            atendimentoToUpdate.MesaId = AtendimentoModel.MesaId;

            var mesaAntiga = await _context.Mesa!.FindAsync(mesaAntigaId);
            mesaAntiga!.Status = false;
            mesaAntiga.HoraAbertura = null;

            var mesaNova = await _context.Mesa!.FindAsync(AtendimentoModel.MesaId);
            mesaNova!.Status = true;
            mesaNova.HoraAbertura = DateTime.Now.AddHours(2);

        
            try{
                bool mesaOcupada = await _context.Mesa!.AnyAsync(m => m.MesaId == AtendimentoModel.MesaId && m.Status);
                if (mesaOcupada) {
                    // ModelState.AddModelError(string.Empty, "A mesa já está ocupada!");
                    TempData["Mensagem"] = "A mesa já está ocupada!!";
                    return RedirectToPage("/Atendimento/Create");
                }
                _context.Update(mesaAntiga);
                _context.Update(mesaNova);
                _context.Update(atendimentoToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
            } catch(DbUpdateException){
                return Page();
            }
        }
    }
}