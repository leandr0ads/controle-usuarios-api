using System.ComponentModel.DataAnnotations;

namespace ControleUsuariosApi.DTOs;

public sealed class AtualizarUsuarioRequest
{
    [Required, StringLength(120, MinimumLength = 2)]
    public string Nome { get; init; } = string.Empty;

    [Required, EmailAddress, StringLength(180)]
    public string Email { get; init; } = string.Empty;
    
    [Required, StringLength(20)]
    public string Telefone { get; init; } = string.Empty;

    public bool Ativo { get; init; }
}
