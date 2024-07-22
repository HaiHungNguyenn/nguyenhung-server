namespace NguyenHung.DAL.Interfaces.BaseInterface;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
    void Rollback();
    Task RollbackAsync();
}