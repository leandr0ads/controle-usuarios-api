using ControleUsuariosApi.Data;
using ControleUsuariosApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleUsuariosApi.Repositories;

public sealed class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<IReadOnlyList<Usuario>> ObterTodosAsync(CancellationToken cancellationToken) =>
        await context.Usuarios
            .AsNoTracking()
            .OrderBy(x => x.Nome)
            .ToListAsync(cancellationToken);

    public Task<Usuario?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken) =>
        context.Usuarios.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<bool> EmailExisteAsync(string email, Guid? ignorarUsuarioId, CancellationToken cancellationToken)
    {
        var emailNormalizado = email.Trim().ToLowerInvariant();
        return context.Usuarios.AnyAsync(
            x => x.Email == emailNormalizado && (!ignorarUsuarioId.HasValue || x.Id != ignorarUsuarioId.Value),
            cancellationToken);
    }

    public Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken) =>
        context.Usuarios.AddAsync(usuario, cancellationToken).AsTask();

    public void Remover(Usuario usuario) => context.Usuarios.Remove(usuario);

    public Task SalvarAlteracoesAsync(CancellationToken cancellationToken) =>
        context.SaveChangesAsync(cancellationToken);
}
