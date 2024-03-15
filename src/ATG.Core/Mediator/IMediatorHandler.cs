using FluentValidation.Results;

namespace ATG.Core.Mediator;

public interface IMediatorHandler
{
    Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
}
