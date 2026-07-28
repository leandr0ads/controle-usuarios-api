namespace ControleUsuariosApi.Domain.Entities;

public sealed class Usuario
{
    private Usuario()
    {
    }

    public Usuario(string nome, string email, string telefone, DateOnly dataNascimento)
    {
        Id = Guid.NewGuid();
        Atualizar(nome, email, telefone,dataNascimento);
        Ativo = true;
        CriadoEm = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;    
    public string Telefone { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; private set; }
    public bool Ativo { get; private set; }


    public DateTime CriadoEm { get; private set; }
    public DateTime? AtualizadoEm { get; private set; }


    public void Atualizar(string nome, string email, string telefone, DateOnly dataNascimento)
    {
        Nome = nome.Trim();
        Email = email.Trim().ToLowerInvariant();
        Telefone = telefone.Trim().ToLowerInvariant();
        DataNascimento = dataNascimento;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void DefinirStatus(bool ativo)
    {
        Ativo = ativo;
        AtualizadoEm = DateTime.UtcNow;
    }
}