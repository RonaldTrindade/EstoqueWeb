using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageProduto
{
    public class IndexModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public IndexModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produtos
                .Include(p => p.Estoque).ToListAsync();
        }
    }
}
