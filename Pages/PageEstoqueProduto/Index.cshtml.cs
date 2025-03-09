using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageEstoqueProduto
{
    public class IndexModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public IndexModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<EstoqueProduto> EstoqueProduto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EstoqueProduto = await _context.Estoques
                .Include(e => e.Usuario).ToListAsync();
        }
    }
}
