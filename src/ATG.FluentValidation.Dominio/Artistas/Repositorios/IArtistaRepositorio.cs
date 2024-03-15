using ATG.FluentValidation.Dominio.Artistas.Entidades;

namespace ATG.FluentValidation.Dominio.Artistas.Repositorios;

public interface IArtistaRepositorio
{
    Task AdicionarAsync(Artista artista);
    Task<Artista?> ObterPorNomeAsync(string nome);
}
