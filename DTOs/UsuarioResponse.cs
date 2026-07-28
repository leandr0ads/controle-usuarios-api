namespace ControleUsuariosApi.DTOs;

public sealed record UsuarioResponse(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    DateOnly DataNascimento,

    bool Ativo,
    DateTime CriadoEm,
    DateTime? AtualizadoEm);
