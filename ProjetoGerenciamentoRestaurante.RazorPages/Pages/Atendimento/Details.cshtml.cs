using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Atendimento
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AtendimentoModel AtendimentoModel { get; set; } = new();
        
        public List<Pedido_ProdutoModel> Pedido_ProdutoList { get; set; } = new();
        
        public Details(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if(id == null || _context.Pedido_Produto == null){
                return NotFound();
            }
            
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

            var pedido_ProdutoList = await _context.Pedido_Produto
            .Include(p => p.Pedido)
                .ThenInclude(p => p!.Garcon)
            .Include(p => p.Pedido)
                .ThenInclude(p => p!.Atendimento)
                    .ThenInclude(a => a!.Mesa)
            .Include(p => p.Produto)
            .Where(e => e.Pedido!.Atendimento!.AtendimentoId == id)
            .ToListAsync();


            if(pedido_ProdutoList == null){
                return NotFound();
            }
            Pedido_ProdutoList = pedido_ProdutoList;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id){
            if(!ModelState.IsValid){
                return Page();
            }
            var atendimentoToUpdate = await _context.Atendimento!.FindAsync(id);

            if(atendimentoToUpdate == null){
                return NotFound();
            }
            
            if(atendimentoToUpdate.AtendimentoFechado){
                var mesaAtualId = atendimentoToUpdate.MesaId;

                atendimentoToUpdate.AtendimentoFechado = false;
                atendimentoToUpdate.DataSaida = null;

                var mesaAtual = await _context.Mesa!.FindAsync(mesaAtualId);
                mesaAtual!.Status = true;
                mesaAtual.HoraAbertura = DateTime.Now.AddHours(1);
            
                try{
                    _context.Update(mesaAtual);
                    _context.Update(atendimentoToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Atendimento/Index");
                } catch(DbUpdateException){
                    return Page();
                }
            }
            else{
                var mesaAtualId = atendimentoToUpdate.MesaId;

                atendimentoToUpdate.AtendimentoFechado = true;
                atendimentoToUpdate.DataSaida = DateTime.Now.AddHours(3);

                var mesaAtual = await _context.Mesa!.FindAsync(mesaAtualId);
                mesaAtual!.Status = false;
                mesaAtual.HoraAbertura = null;
            
                try{
                    _context.Update(mesaAtual);
                    _context.Update(atendimentoToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Atendimento/Index");
                } catch(DbUpdateException){
                    return Page();
                }
            }
        }

    }
}