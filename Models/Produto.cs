
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public required string Nome { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A quantidade disponível é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int QuantidadeDisponivel { get; set; }

        // Chave estrangeira para EstoqueProduto
        public int EstoqueId { get; set; }

        // Propriedade de navegação para EstoqueProduto
        public EstoqueProduto Estoque { get; set; }

        // Coleção de movimentações
        public ICollection<SaidaEntradaProduto> Movimentacoes { get; set; } = new List<SaidaEntradaProduto>();
    }
}