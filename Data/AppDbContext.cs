using ControleUsuariosApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleUsuariosApi.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var usuario = modelBuilder.Entity<Usuario>();
        usuario.ToTable("Usuarios");
        usuario.HasKey(x => x.Id);
        usuario.Property(x => x.Nome).HasMaxLength(120).IsRequired();
        usuario.Property(x => x.Email).HasMaxLength(180).IsRequired();
        usuario.HasIndex(x => x.Email).IsUnique();
        usuario.Property(x => x.Ativo).IsRequired();
        usuario.Property(x => x.CriadoEm).IsRequired();
    }
}
