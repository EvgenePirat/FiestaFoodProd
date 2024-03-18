using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Data;

public partial class StContext : DbContext
{
    public StContext()
    {
    }

    public StContext(DbContextOptions<StContext> options)
        : base(options)
    {
        try
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator is not null)
            {
                if (!databaseCreator.CanConnect()) 
                    databaseCreator.Create();
                if (!databaseCreator.HasTables()) 
                    databaseCreator.CreateTables();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomerInfo> CustomerInfos { get; set; }
    public DbSet<PaymentInfo> PaymentInfos { get; set; }
    public DbSet<Quantity> Quantities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
