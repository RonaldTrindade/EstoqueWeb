﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageUsuario
{
    public class EditModel : PageModel
    {
        private readonly EstoqueWeb.Data.AppDbContext _context;

        public EditModel(EstoqueWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario =  await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            Usuario = usuario;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(Usuario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["Sucesso"] = "Usuário Editado com sucesso!";
            return RedirectToPage("./Index");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
