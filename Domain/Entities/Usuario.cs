namespace ControleUsuariosApi.Domain.Entities;

public sealed class Usuario
{
    private Usuario() { }

    public Usuario(string nome, string email, string telefone)
    {
        Id = Guid.NewGuid();
        Atualizar(nome, email, telefone);
        Ativo = true;
        CriadoEm = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    
    public string Telefone { get; set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime? AtualizadoEm { get; private set; }


    public void Atualizar(string nome, string email, string telefone)
    {
        Nome = nome.Trim();
        Email = email.Trim().ToLowerInvariant();
        Telefone = telefone.Trim().ToLowerInvariant();
        AtualizadoEm = DateTime.UtcNow;
    }

    public void DefinirStatus(bool ativo)
    {
        Ativo = ativo;
        AtualizadoEm = DateTime.UtcNow;
    }
}
