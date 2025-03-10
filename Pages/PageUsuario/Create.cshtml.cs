using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageUsuario
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
            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();
            TempData["Sucesso"] = "Usuário cadastrado com sucesso!";
            return RedirectToPage("./Index");
        }
    }
}
