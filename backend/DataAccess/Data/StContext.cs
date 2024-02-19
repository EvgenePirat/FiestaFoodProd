using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public partial class StContext : DbContext
{
    public StContext()
    {
    }

    public StContext(DbContextOptions<StContext> options)
        : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB;Initial Catalog=shopTemplateDb;Trusted_Connection=True;TrustServerCertificate=True;");
    //    }
    //}

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Count> Counts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomerInfo> CustomerInfos { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
