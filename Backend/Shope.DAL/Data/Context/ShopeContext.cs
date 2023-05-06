using Microsoft.EntityFrameworkCore;

namespace Shope.DAL;

public class ShopeContext : DbContext

{
    public DbSet<Categories> categories { get; set; }
    public DbSet<Product> prouducts { get; set; }
    public ShopeContext(DbContextOptions<ShopeContext> options) : base(options)
    {

    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    #region Seeding Categories
    //    modelBuilder.Entity<Categories>().HasData
    //        (
    //        new Categories
    //        {
    //            Id = Guid.NewGuid(),
    //            Name = "plastic",
    //        }
    //        );
    //    #endregion
    //}

}

