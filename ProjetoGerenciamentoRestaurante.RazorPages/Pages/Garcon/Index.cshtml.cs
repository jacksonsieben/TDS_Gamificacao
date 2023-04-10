using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Garcon
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        

        public void OnGet()
        {
        }
    }
}