using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Pedido
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        public AtendimentoModel AtendimentoModel { get; set; } = new();
        [BindProperty]
        public PedidoModel PedidoModel { get; set; } = new();
        public Pedido_ProdutoModel Pedido_ProdutoModel { get; set; } = new();
        public List<GarconModel> GarconList { get; set; } = new();
        public List<ProdutoModel> ProdutoList { get; set; } = new();
        public List<Pedido_ProdutoModel> Pedido_ProdutoList { get; set; } = new();
        
        public Create(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            var atendimentoModel = await _context.Atendimento!.FirstOrDefaultAsync(e => e.AtendimentoId == id);
            if(atendimentoModel == null){
                return NotFound();
            }
            AtendimentoModel = atendimentoModel;

            Pedido_ProdutoList = await _context.Pedido_Produto!.ToListAsync();
            GarconList = await _context.Garcon!.ToListAsync();
            ProdutoList = await _context.Produto!.ToListAsync();
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id){
            if(!ModelState.IsValid){
                return Page();
            }

            try{
                _context.Pedido!.Add(PedidoModel);

                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
                
            } catch(DbUpdateException){
                // return Page();
                return RedirectToPage("/Atendimento/Index");
            }
        }
    }
}