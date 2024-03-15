using ATG.Core;
using ATG.Core.Mediator;
using ATG.FluentValidation.Aplicacao.Artistas.Commands;
using ATG.FluentValidation.Dominio.Artistas.Entidades;
using ATG.FluentValidation.Dominio.Artistas.Repositorios;
using FluentValidation.Results;
using MediatR;

namespace ATG.FluentValidation.Aplicacao.Artistas.Handlers;

public class ArtistaCommandHandler : CommandHandler,
                                     IRequestHandler<NovoArtistaCommand, ValidationResult>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IArtistaRepositorio _artistaRepositorio;

    public ArtistaCommandHandler(IUnitOfWork unitOfWork,
                                 IArtistaRepositorio artistaRepositorio)
    {
        _unitOfWork = unitOfWork;
        _artistaRepositorio = artistaRepositorio;
    }

    public async Task<ValidationResult> Handle(NovoArtistaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            if (!request.EhValido())
                return request.ValidationResult!;            

            var artistaExistente = await _artistaRepositorio.ObterPorNomeAsync(request.Nome);

            if (artistaExistente is not null)
            {
                AdicionarErro("Artista já cadastrado.");
                return ValidationResult;
            }

            var artista = new Artista(request.Id, request.Nome);

            await _artistaRepositorio.AdicionarAsync(artista);

            _unitOfWork.Commit();
        }
        catch
        {
            _unitOfWork.Rollback();
            AdicionarErro("Houve um erro ao persistir os dados");
        }
        return ValidationResult;
    }
}
