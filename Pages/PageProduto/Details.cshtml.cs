using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageProduto
{
    public class DetailsModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public DetailsModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            Produto = await _context.Produtos
                .Include(p => p.Estoque) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}