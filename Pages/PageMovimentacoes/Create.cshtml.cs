﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EstoqueWeb.Data;
using EstoqueWeb.Models;

namespace EstoqueWeb.Pages.PageMovimentacoes
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
        ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public SaidaEntradaProduto SaidaEntradaProduto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
                // Converte a DataOperacao para UTC
                SaidaEntradaProduto.DataOperacao = SaidaEntradaProduto.DataOperacao.ToUniversalTime();
            
                _context.Movimentacoes.Add(SaidaEntradaProduto);
                await _context.SaveChangesAsync();
            TempData["Sucesso"] = "Movimentação cadastrada com sucesso!";
            return RedirectToPage("./Index");
      
        }
    }
}
