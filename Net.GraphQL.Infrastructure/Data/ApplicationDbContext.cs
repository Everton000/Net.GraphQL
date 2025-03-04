using Microsoft.EntityFrameworkCore;
using Net.GraphQL.Domain.Entities;

namespace Net.GraphQL.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.CpfOrCnpj)
            .IsUnique();

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<Dictionary<string, object>>(
                "OrderProduct",
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId"));
    }
}