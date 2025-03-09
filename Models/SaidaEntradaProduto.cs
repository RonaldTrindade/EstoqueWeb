
using System;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class SaidaEntradaProduto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo de operação é obrigatório.")]
        public required string TipoOperacao { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        public DateTime DataOperacao { get; set; } = DateTime.Now;

        // Chave estrangeira para Produto
        public int ProdutoId { get; set; }

        // Propriedade de navegação para Produto
        public Produto Produto { get; set; }

        // Chave estrangeira para EstoqueProduto
        public int EstoqueId { get; set; }

        // Propriedade de navegação para EstoqueProduto
        public EstoqueProduto Estoque { get; set; }
    }
}