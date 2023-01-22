using DragonsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonsApp.Database;

public class DragonsDbContext : DbContext
{
    public DbSet<Dragon> Dragons { get; set; } = null!;
    public DbSet<History> Histories { get; set; } = null!;

    public DragonsDbContext(DbContextOptions<DragonsDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
