using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class NutrientRepository : GenericRepository<Nutrient>, INutrientRepository
{
    public NutrientRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}