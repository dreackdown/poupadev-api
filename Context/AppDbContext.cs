using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace PoupaDev.API.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ObjetivoFinanceiro> Objetivos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<ObjetivoFinanceiro>(e =>
      {
        e.HasKey(of => of.Id);

        e.Property(of => of.ValorObjetivo)
          .HasColumnType("decimal(18,2)");

        e.HasMany(of => of.Operacoes)
          .WithOne()
          .HasForeignKey(op => op.IdObjetivo)
          .OnDelete(DeleteBehavior.Restrict);
      });

      builder.Entity<Operacao>(e =>
      {
        e.HasKey(op => op.Id);

        e.Property(op => op.Valor)
          .HasColumnType("decimal(18,2)");
      });
    }
  }
}