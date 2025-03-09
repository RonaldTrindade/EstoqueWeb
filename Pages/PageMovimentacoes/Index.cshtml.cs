using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageMovimentacoes
{
    public class IndexModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public IndexModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<SaidaEntradaProduto> SaidaEntradaProduto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SaidaEntradaProduto = await _context.Movimentacoes
                .Include(s => s.Estoque)
                .Include(s => s.Produto).ToListAsync();
        }
    }
}
