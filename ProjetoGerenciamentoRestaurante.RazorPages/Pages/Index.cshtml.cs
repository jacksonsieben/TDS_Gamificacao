using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public List<PedidoModel>PedidoList { get; set; } = new();
        public List<GarconModel>GarconList { get; set; } = new();
        public List<PedidoView>PedidoViewList { get; set; } = new();
        public List<Pedido_ProdutoModel>PedidoProdutoList { get; set; }
        
        public Index(AppDbContext context){
            _context = context;
        }
        public PedidoModel pedidoModel { get; set; } = new();
       
        public async Task<IActionResult> OnGetAsync(){
            PedidoList = await _context.Pedido!
                                        .Include(g => g.Garcon)
                                        .Include(a => a.Atendimento)
                                        .Include(m => m.Atendimento!.Mesa)
                                        .ToListAsync();

            PedidoProdutoList = await _context.Pedido_Produto!
                                                .Include(p => p.Pedido)
                                                .Include(x => x.Produto)
                                                .ToListAsync();

            GarconList = await _context.Garcon!.ToListAsync();

            foreach (var g in GarconList){
                PedidoView pedido = new();
                pedido.Garcon = g;
                PedidoViewList.Add(pedido);
            }
            
            foreach (var p in PedidoList){
                if (p.Atendimento!.AtendimentoFechado){
                    foreach (var v in PedidoViewList) {
                        if(p.GarconId == v.Garcon!.GarconId){
                            v.countPedidos += 1;
                        }
                    }
                }
            }

            foreach (var p in PedidoProdutoList){
                foreach (var v in PedidoViewList){
                    if(p.Pedido!.GarconId == v.Garcon!.GarconId){
                        var total = p.Produto!.Preco * p.Quantidade;
                        v.totalVendas += total;
                        v.quantidadeTotal += p.Quantidade;
                    }
                    
                }
            }            
            return Page();
        }

    }
}