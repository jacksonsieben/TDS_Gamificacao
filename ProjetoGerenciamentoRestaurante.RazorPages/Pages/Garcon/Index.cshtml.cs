using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Garcon
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<GarconModel> GarconList { get; set; } = new();
        public Index(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(){
            GarconList = await _context.Garcon!.ToListAsync();
            return Page();
        }
    }
}