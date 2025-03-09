using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class EstoqueProduto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do estoque é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "A localização do estoque é obrigatória.")]
        public required string Localizacao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<SaidaEntradaProduto> Movimentacoes { get; set; } = new List<SaidaEntradaProduto>();
    }
}