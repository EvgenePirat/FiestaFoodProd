using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngridient> DishIngridients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Quantity> Quantities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Quantity)
            .WithOne(q => q.Ingredient)
            .HasForeignKey<Quantity>(q => q.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DishIngridient>()
            .HasKey(di => new { di.DishId, di.IngredientId });

        modelBuilder.Entity<DishIngridient>()
            .HasOne(di => di.Ingredient)
            .WithMany(ing => ing.DishIngridients)
            .HasForeignKey(di => di.IngredientId);

        modelBuilder.Entity<DishIngridient>()
            .HasOne(di => di.Dish)
            .WithMany(di => di.DishIngridients)
            .HasForeignKey(di => di.DishId);

        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => od.OrderId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Order)
            .WithOne(o => o.OrderDetail)
            .HasForeignKey<OrderDetail>(od => od.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.DishId });

        modelBuilder.Entity<OrderItem>()
            .HasOne<Order>(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne<Dish>(oi => oi.Dish)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.DishId);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
