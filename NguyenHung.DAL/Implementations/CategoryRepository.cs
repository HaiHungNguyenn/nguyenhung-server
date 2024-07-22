using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}