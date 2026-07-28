using ControleUsuariosApi.Domain.Entities;
using ControleUsuariosApi.DTOs;
using ControleUsuariosApi.Repositories;

namespace ControleUsuariosApi.Services;

public sealed class UsuarioService(IUsuarioRepository repository) : IUsuarioService
{
    public async Task<IReadOnlyList<UsuarioResponse>> ObterTodosAsync(CancellationToken cancellationToken)
    {
        var usuarios = await repository.ObterTodosAsync(cancellationToken);
        return usuarios.Select(Mapear).ToList();
    }

    public async Task<UsuarioResponse> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await ObterEntidadeAsync(id, cancellationToken);
        return Mapear(usuario);
    }

    public async Task<UsuarioResponse> CriarAsync(CriarUsuarioRequest request, CancellationToken cancellationToken)
    {
        if (await repository.EmailExisteAsync(request.Email, null, cancellationToken))
            throw new InvalidOperationException("Já existe um usuário cadastrado com este e-mail.");

        var usuario = new Usuario(request.Nome, request.Email);
        await repository.AdicionarAsync(usuario, cancellationToken);
        await repository.SalvarAlteracoesAsync(cancellationToken);

        return Mapear(usuario);
    }

    public async Task<UsuarioResponse> AtualizarAsync(Guid id, AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuario = await ObterEntidadeAsync(id, cancellationToken);

        if (await repository.EmailExisteAsync(request.Email, id, cancellationToken))
            throw new InvalidOperationException("Já existe outro usuário cadastrado com este e-mail.");

        usuario.Atualizar(request.Nome, request.Email);
        usuario.DefinirStatus(request.Ativo);
        await repository.SalvarAlteracoesAsync(cancellationToken);

        return Mapear(usuario);
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await ObterEntidadeAsync(id, cancellationToken);
        repository.Remover(usuario);
        await repository.SalvarAlteracoesAsync(cancellationToken);
    }

    private async Task<Usuario> ObterEntidadeAsync(Guid id, CancellationToken cancellationToken) =>
        await repository.ObterPorIdAsync(id, cancellationToken)
        ?? throw new KeyNotFoundException("Usuário não encontrado.");

    private static UsuarioResponse Mapear(Usuario usuario) => new(
        usuario.Id,
        usuario.Nome,
        usuario.Email,
        usuario.Ativo,
        usuario.CriadoEm,
        usuario.AtualizadoEm);
}
