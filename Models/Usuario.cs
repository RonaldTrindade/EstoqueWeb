
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public required string Email { get; set; }

        public ICollection<EstoqueProduto> Estoques { get; set; } = new List<EstoqueProduto>();
    }
}
