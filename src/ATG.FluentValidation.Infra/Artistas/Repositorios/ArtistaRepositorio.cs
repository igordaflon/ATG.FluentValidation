using ATG.FluentValidation.Dominio.Artistas.Entidades;
using ATG.FluentValidation.Dominio.Artistas.Repositorios;

namespace ATG.FluentValidation.Infra.Artistas.Repositorios;

public class ArtistaRepositorio : IArtistaRepositorio
{
    public async Task AdicionarAsync(Artista artista)
    {
        Console.WriteLine("Artista adicionado");
    }

    public async Task<Artista?> ObterPorNomeAsync(string nome)
    {
        return new Artista(Guid.NewGuid(), "Fulano de Tal");
    }
}
