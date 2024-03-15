using ATG.Core.Mediator;
using FluentValidation;

namespace ATG.FluentValidation.Aplicacao.Artistas.Commands;

public class NovoArtistaCommand : Command
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;

    public NovoArtistaCommand(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public override bool EhValido()
    {
        ValidationResult = new NovoArtistaValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public class NovoArtistaValidation : AbstractValidator<NovoArtistaCommand>
    {
        public NovoArtistaValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do artista inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do artista é obrigatório");
        }
    }
}
