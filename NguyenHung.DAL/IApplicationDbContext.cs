using Microsoft.EntityFrameworkCore;

namespace NguyenHung.DAL;

public interface IApplicationDbContext
{
    DbSet<T> CreateSet<T>() where T : class;
    void Attach<T>(T entity) where T : class;
    void SetModified<T>(T entity) where T : class;
    void SetDeleted<T>(T entity) where T : class;
    void Refresh<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void SaveChanges();
    Task SaveChangesAsync();
    void Migrate();
}
