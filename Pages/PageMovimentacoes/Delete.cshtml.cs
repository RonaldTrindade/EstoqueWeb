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
    public class DeleteModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public DeleteModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SaidaEntradaProduto SaidaEntradaProduto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaentradaproduto = await _context.Movimentacoes.FirstOrDefaultAsync(m => m.Id == id);

            if (saidaentradaproduto == null)
            {
                return NotFound();
            }
            else
            {
                SaidaEntradaProduto = saidaentradaproduto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saidaentradaproduto = await _context.Movimentacoes.FindAsync(id);
            if (saidaentradaproduto != null)
            {
                SaidaEntradaProduto = saidaentradaproduto;
                _context.Movimentacoes.Remove(SaidaEntradaProduto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
