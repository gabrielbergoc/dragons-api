using DragonsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonsApp.Database;

public class DragonsDbContext : DbContext
{
    public DbSet<Dragon> Dragons { get; set; } = null!;
    public DbSet<History> Histories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            // .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            // .EnableSensitiveDataLogging()
            .UseSqlServer("data source=DESKTOP-Q3DBTVQ;initial catalog=Dragons;trusted_connection=true;Trust Server Certificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Dragon>()
            .HasData(
                new Dragon() { Id = 1, Name = "Toothless", Title = "The Great One Without Teeth" },
                new Dragon() { Id = 2, Name = "Fafnir", Title = "The Greedy One With Riches" },
                new Dragon() { Id = 3, Name = "Smaug", Title = "The Desolation of Greediness" },
                new Dragon() { Id = 4, Name = "Rex", Title = "The Great Friend" },
                new Dragon() { Id = 5, Name = "Adaman", Title = "The Strong One" },
                new Dragon() { Id = 6, Name = "Margoneth", Title = "The One I Invented" }
            );
    }
}
