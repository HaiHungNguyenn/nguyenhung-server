using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class CookingWearRepository: GenericRepository<CookingWear>, ICookingWearRepository
{
    public CookingWearRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}