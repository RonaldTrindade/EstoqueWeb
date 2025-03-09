using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageProduto
{
    public class CreateModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public CreateModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["EstoqueId"] = new SelectList(_context.Estoques, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Produto.EstoqueId == 0)
            {
                ModelState.AddModelError("Produto.EstoqueId", "selecione um estoque válido.");
                return Page();
            }

            _context.Produtos.Add(Produto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
