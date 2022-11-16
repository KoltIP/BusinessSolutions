using BusinessSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessSolutions.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Provider> Providers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>().ToTable("orderitems");
        modelBuilder.Entity<OrderItem>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<OrderItem>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<OrderItem>().Property(x => x.Quantity).IsRequired();
        modelBuilder.Entity<OrderItem>().HasIndex(x => x.Quantity).IsUnique();
        modelBuilder.Entity<OrderItem>().Property(x => x.Unit).IsRequired();
        modelBuilder.Entity<OrderItem>().HasIndex(x => x.Unit).IsUnique();

        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(x => x.Number).IsRequired();
        modelBuilder.Entity<Order>().HasIndex(x => x.Number).IsUnique();
        modelBuilder.Entity<Order>().Property(x => x.Date).IsRequired();
        modelBuilder.Entity<Order>().HasIndex(x => x.Date).IsUnique();

        modelBuilder.Entity<Provider>().ToTable("providers");
        modelBuilder.Entity<Provider>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Provider>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<OrderItem>().HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Order>().HasOne(x => x.Provider).WithMany(x => x.Orders).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Cascade);
    }

}
