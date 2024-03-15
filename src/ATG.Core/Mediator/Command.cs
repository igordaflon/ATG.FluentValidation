using FluentValidation.Results;
using MediatR;

namespace ATG.Core.Mediator;

public abstract class Command : IRequest<ValidationResult>
{
    public DateTime TimeStamp { get; private set; }
    public ValidationResult? ValidationResult { get; set; }

    protected Command()
    {
        TimeStamp = DateTime.Now;
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }
}
