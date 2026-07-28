namespace ControleUsuariosApi.DTOs;

public sealed record UsuarioResponse(
    Guid Id,
    string Nome,
    string Email,
    DateOnly DataNascimento,
    string Telefone,
    bool Ativo,
    DateTime CriadoEm,
    DateTime? AtualizadoEm);
