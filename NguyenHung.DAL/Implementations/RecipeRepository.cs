using NguyenHung.Common.Attributes;
using NguyenHung.DAL.Implementations.BaseImplementation;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Implementations;
[ServiceRegister]
public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }
}