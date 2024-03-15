using ATG.Core.Mediator;
using ATG.FluentValidation.Aplicacao.Artistas.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ATG.FluentValidation.API.Controllers.Artistas;

[Route("api/artistas")]
public class ArtistaController : MainController
{
    private readonly IMediatorHandler _mediator;

    public ArtistaController(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Inserir um novo artista
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Inserir(NovoArtistaCommand request)
    {
        var response = await _mediator.EnviarComando(request);

        return CustomResponse(response);
    }
}
