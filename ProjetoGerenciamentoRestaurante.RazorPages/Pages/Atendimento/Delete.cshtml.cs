using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        public AtendimentoModel AtendimentoModel { get; set; } = new();
        public Pedido_ProdutoModel Pedido_ProdutoModel { get; set; } = new();
        
        public Delete(AppDbContext context){
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

            var pedido_ProdutoModel = await _context.Pedido_Produto!
            .Include(p => p.Pedido)
                .ThenInclude(p => p!.Garcon)
            .Include(p => p.Pedido)
                .ThenInclude(p => p!.Atendimento)
                    .ThenInclude(a => a!.Mesa)
            .Include(p => p.Produto)
            .Where(e => e.Pedido!.Atendimento!.AtendimentoId == id)
            .FirstOrDefaultAsync();

            if(pedido_ProdutoModel != null){
                TempData["Mensagem"] = "Esse Atendimento tem Pedidos!!";
                return RedirectToPage("/Atendimento/Index");
            }

            AtendimentoModel = atendimentoModel;
            Pedido_ProdutoModel = pedido_ProdutoModel!;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            var atendimentoToDelete = await _context.Atendimento!.FindAsync(id);

            if(atendimentoToDelete == null){
                return NotFound();
            }

            var mesaAntigaId = atendimentoToDelete.MesaId;

            try{
                var mesaAntiga = await _context.Mesa!.FindAsync(mesaAntigaId);
                mesaAntiga!.Status = false;
                mesaAntiga.HoraAbertura = null;
                
                _context.Update(mesaAntiga);
                _context.Atendimento.Remove(atendimentoToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Atendimento/Index");
            } catch(DbUpdateException){
                return Page();
            }
        }
    }
}