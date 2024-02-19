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

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomerInfo> CustomerInfos { get; set; }
    public DbSet<Size> Sizes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
