using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Interfaces.BaseInterface;

namespace NguyenHung.DAL.Implementations.BaseImplementation;
[ServiceRegister]
public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;

    public UnitOfWork(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        try
        {
            GC.SuppressFinalize(this);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Rollback()
    {
        Console.WriteLine("Transaction rollback");
    }

    public async Task RollbackAsync()
    {
        Console.WriteLine("Transaction rollback");
        await Task.CompletedTask;	
    }
}