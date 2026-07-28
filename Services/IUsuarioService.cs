using ControleUsuariosApi.DTOs;

namespace ControleUsuariosApi.Services;

public interface IUsuarioService
{
    Task<IReadOnlyList<UsuarioResponse>> ObterTodosAsync(CancellationToken cancellationToken);
    Task<UsuarioResponse> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UsuarioResponse> CriarAsync(CriarUsuarioRequest request, CancellationToken cancellationToken);
    Task<UsuarioResponse> AtualizarAsync(Guid id, AtualizarUsuarioRequest request, CancellationToken cancellationToken);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken);
}
