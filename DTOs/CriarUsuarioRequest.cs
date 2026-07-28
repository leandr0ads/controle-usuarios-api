using System.ComponentModel.DataAnnotations;

namespace ControleUsuariosApi.DTOs;

public sealed class CriarUsuarioRequest
{
    [Required, StringLength(120, MinimumLength = 2)]
    public string Nome { get; init; } = string.Empty;

    [Required, EmailAddress, StringLength(180)]
    public string Email { get; init; } = string.Empty;
    
    [Required]
    public DateOnly DataNascimento { get; init; }
}
