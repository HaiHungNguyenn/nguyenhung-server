using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class RecipeCookingWearRepository : GenericRepository<RecipeCookingWear>, IRecipeCookingWearRepository
{
    public RecipeCookingWearRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}