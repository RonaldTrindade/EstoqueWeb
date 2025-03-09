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
    public class DetailsModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public DetailsModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public EstoqueProduto EstoqueProduto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoqueproduto = await _context.Estoques.FirstOrDefaultAsync(m => m.Id == id);
            if (estoqueproduto == null)
            {
                return NotFound();
            }
            else
            {
                EstoqueProduto = estoqueproduto;
            }
            return Page();
        }
    }
}
