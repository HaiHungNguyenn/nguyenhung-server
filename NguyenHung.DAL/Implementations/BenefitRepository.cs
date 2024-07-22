using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class BenefitRepository : GenericRepository<Benefit>, IBenefitRepository
{
    public BenefitRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}