namespace ATG.Core;

public class UnitOfWork : IUnitOfWork
{
    public void BeginTransaction()
    {
    }

    public void Commit()
    {
    }

    public void Dispose()
    {
    }

    public void Rollback()
    {
    }
}

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();

    void Rollback();

    void Commit();
}
