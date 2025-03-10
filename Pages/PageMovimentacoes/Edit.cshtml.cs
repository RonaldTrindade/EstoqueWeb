using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageMovimentacoes
{
    public class EditModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public EditModel(EstoqueWeb.Data.AppDbContext context)
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

            var saidaentradaproduto =  await _context.Movimentacoes.FirstOrDefaultAsync(m => m.Id == id);
            if (saidaentradaproduto == null)
            {
                return NotFound();
            }
            SaidaEntradaProduto = saidaentradaproduto;
           ViewData["EstoqueId"] = new SelectList(_context.Estoques, "Id", "Nome");
           ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            SaidaEntradaProduto.DataOperacao = SaidaEntradaProduto.DataOperacao.ToUniversalTime();
            _context.Attach(SaidaEntradaProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaEntradaProdutoExists(SaidaEntradaProduto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["Sucesso"] = "Movimentação Editada com sucesso!";
            return RedirectToPage("./Index");
        }

        private bool SaidaEntradaProdutoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.Id == id);
        }
    }
}
