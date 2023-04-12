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

            atendimentoToUpdate.MesaId = AtendimentoModel.MesaId;

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
            } catch(DbUpdateException){
                return Page();
            }
        }
    }
}