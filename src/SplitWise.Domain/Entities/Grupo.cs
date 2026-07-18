namespace SplitWise.Domain.Entities;

public class Grupo
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private  set; }

    public Grupo(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome informado deve ser válido.", nameof(nome));
        this.Nome = nome;
            
        this.Id = Guid.NewGuid();
        this.DataCriacao = DateTime.UtcNow;
    }
    
    protected  Grupo()
    {
    }
}
