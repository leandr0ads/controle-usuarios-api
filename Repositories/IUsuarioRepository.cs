using ControleUsuariosApi.Domain.Entities;

namespace ControleUsuariosApi.Repositories;

public interface IUsuarioRepository
{
    Task<IReadOnlyList<Usuario>> ObterTodosAsync(CancellationToken cancellationToken);
    Task<Usuario?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> EmailExisteAsync(string email, Guid? ignorarUsuarioId, CancellationToken cancellationToken);
    Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken);
    void Remover(Usuario usuario);
    Task SalvarAlteracoesAsync(CancellationToken cancellationToken);
}
