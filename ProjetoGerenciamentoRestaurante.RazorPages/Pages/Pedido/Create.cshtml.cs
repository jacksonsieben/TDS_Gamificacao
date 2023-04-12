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

        [BindProperty]
        public Pedido_ProdutoModel Pedido_ProdutoModel { get; set; } = new();
        public List<GarconModel> GarconList { get; set; } = new();
        public List<ProdutoModel> ProdutoList { get; set; } = new();
        public List<Pedido_ProdutoModel> Pedido_ProdutoList { get; set; } = new();
        
        public Create(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Atendimento == null){
                return NotFound();
            }

            var atendimentoModel = await _context.Atendimento
            .FirstOrDefaultAsync(e => e.AtendimentoId == id);

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
                return RedirectToAction("/Pedido/Create/"+id);
            }

            try{
                _context.Pedido!.Add(PedidoModel);

                await _context.SaveChangesAsync();

                Pedido_ProdutoModel.PedidoId = PedidoModel.PedidoId;
                _context.Pedido_Produto!.Add(Pedido_ProdutoModel);

                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
                
            } catch(DbUpdateException){
                return RedirectToAction("/Pedido/Create/"+id);
            }
        }
    }
}