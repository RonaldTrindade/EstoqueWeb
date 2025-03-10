using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageEstoqueProduto
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
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public EstoqueProduto EstoqueProduto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (EstoqueProduto.UsuarioId == 0)
            {
                ModelState.AddModelError("EstoqueProduto.UsuarioId", "Selecione um usuário válido.");
                return Page();
            }

            _context.Estoques.Add(EstoqueProduto);
            await _context.SaveChangesAsync();
            TempData["Sucesso"] = "Estoque cadastrado com sucesso!";
            return RedirectToPage("./Index");
        }
    }
}
