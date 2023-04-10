using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<AtendimentoModel> AtendimentoList { get; set; } = new();
        public Index(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            AtendimentoList = await _context.Atendimento!
            .Include(p => p.Mesa)
            .ToListAsync();
            
            return Page();
        }
    }
}