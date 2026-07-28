namespace ControleUsuariosApi.DTOs;

public sealed record UsuarioResponse(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    DateOnly DataNascimento,
    string NomeResponsavel,

    bool Ativo,
    DateTime CriadoEm,
    DateTime? AtualizadoEm);
