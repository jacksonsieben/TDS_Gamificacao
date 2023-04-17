using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Mesa
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<MesaModel> MesaList { get; set; } = new();
        public Index(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            MesaList = await _context.Mesa!.ToListAsync();
            return Page();
        }
    }
}