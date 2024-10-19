using CadastroCashback.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCashback.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options) {}
    
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Cashback> Cashbacks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Configure the Product entity
        modelBuilder.Entity<ContatoModel>()
            .ToTable("Contatos")  // Specify table name
            .HasKey(p => p.Id); // Specify primary key

        modelBuilder.Entity<Usuario>()
          .ToTable("Usuarios")
          .HasKey(p => p.Id);

        modelBuilder.Entity<Usuario>()
          .Property(p => p.Nome)
          .IsRequired()  // Make Name required
          .HasMaxLength(100);  // Set maximum length

        modelBuilder.Entity<Usuario>()
          .Property(p => p.Email)
          .IsRequired()  // Make Name required
          .HasMaxLength(100);  // Set maximum length

        modelBuilder.Entity<Transacao>()
          .ToTable("Transacoes")
          .HasKey(p => p.Id);

        modelBuilder.Entity<Cashback>()
          .ToTable("Cashbacks")
          .HasKey(p => p.Id);
    }
}