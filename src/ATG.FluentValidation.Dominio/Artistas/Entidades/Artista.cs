namespace ATG.FluentValidation.Dominio.Artistas.Entidades;

public class Artista
{
    public virtual Guid Id { get; protected set; }
    public virtual string Nome { get; protected set; } = string.Empty;

    protected Artista() { }

    public Artista(Guid id, string nome)
    {
        SetId(id);
        SetNome(nome);
    }

    public virtual void SetId(Guid id)
    {
        Id = id;
    }

    public virtual void SetNome(string nome)
    {
        Nome = nome;
    }
}
