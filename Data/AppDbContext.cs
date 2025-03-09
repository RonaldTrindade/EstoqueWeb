using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Models;

namespace EstoqueWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EstoqueProduto> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SaidaEntradaProduto> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das chaves primárias
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<EstoqueProduto>().HasKey(e => e.Id);
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<SaidaEntradaProduto>().HasKey(s => s.Id);

            // Configuração do relacionamento entre EstoqueProduto e Usuario
            modelBuilder.Entity<EstoqueProduto>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Estoques)
                .HasForeignKey(e => e.UsuarioId);

            // Configuração do relacionamento entre Produto e EstoqueProduto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Estoque)
                .WithMany(e => e.Produtos)
                .HasForeignKey(p => p.EstoqueId);

            // Configuração do relacionamento entre SaidaEntradaProduto e Produto
            modelBuilder.Entity<SaidaEntradaProduto>()
                .HasOne(s => s.Produto)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(s => s.ProdutoId);

            // Configuração do relacionamento entre SaidaEntradaProduto e EstoqueProduto
            modelBuilder.Entity<SaidaEntradaProduto>()
                .HasOne(s => s.Estoque)
                .WithMany(e => e.Movimentacoes)
                .HasForeignKey(s => s.EstoqueId);
        }
    }
}
