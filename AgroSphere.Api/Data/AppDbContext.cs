using AgroSphere.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgroSphere.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Fazenda> Fazendas { get; set; }

    public DbSet<Plantio> Plantios { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fazenda>()
            .HasMany(f => f.Plantios)
            .WithOne(p => p.Fazenda)
            .HasForeignKey(p => p.FazendaId);

        base.OnModelCreating(modelBuilder);
    }
}