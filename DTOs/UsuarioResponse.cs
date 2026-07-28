namespace ControleUsuariosApi.DTOs;

public sealed record UsuarioResponse(
    Guid Id,
    string Nome,
    string Email,
    bool Ativo,
    DateTime CriadoEm,
    DateTime? AtualizadoEm);
