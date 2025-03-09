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

namespace EstoqueWeb.Pages.PageEstoqueProduto
{
    public class EditModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public EditModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EstoqueProduto EstoqueProduto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoqueproduto =  await _context.Estoques.FirstOrDefaultAsync(m => m.Id == id);
            if (estoqueproduto == null)
            {
                return NotFound();
            }
            EstoqueProduto = estoqueproduto;
           ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (EstoqueProduto.UsuarioId == 0)
            {
                ModelState.AddModelError("EstoqueProduto.UsuarioId", "Selecione um usuário válido.");
                return Page();
            }

            _context.Attach(EstoqueProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueProdutoExists(EstoqueProduto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstoqueProdutoExists(int id)
        {
            return _context.Estoques.Any(e => e.Id == id);
        }
    }
}
