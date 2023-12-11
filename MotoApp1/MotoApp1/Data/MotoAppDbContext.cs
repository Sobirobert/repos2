namespace MotoApp.Data;

using Microsoft.EntityFrameworkCore;

public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
}