using Microsoft.EntityFrameworkCore;
using NguyenHung.DAL.Configurations;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<CookingWear> CookingWears { get; set; }
    public DbSet<RecipeCookingWear> RecipeCookingWears { get; set; }
    public DbSet<Benefit> Benefits { get; set; }

    public ApplicationDbContext()
    {
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=nguyenhung-server.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        modelBuilder.ApplyConfiguration(new NutrientConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new CookingWearConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeCookingWearConfiguration());
    }

    public DbSet<T> CreateSet<T>() where T : class
    {
        return base.Set<T>();
    }

    public new void Attach<T>(T entity) where T : class
    {
        base.Attach(entity);
    }

    public void SetModified<T>(T entity) where T : class
    {
        base.Entry(entity).State = EntityState.Modified;
    }

    public void SetDeleted<T>(T entity) where T : class
    {
        base.Entry(entity).State = EntityState.Deleted;
    }

    public void Refresh<T>(T entity) where T : class
    {
        base.Entry(entity).Reload();
    }

    public new void Update<T>(T entity) where T : class
    {
        base.Update(entity);
    }

    public new void SaveChanges()
    {
        base.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    public void Migrate()
    {
        if(base.Database.GetPendingMigrations().Any())
            base.Database.Migrate();
    }
}