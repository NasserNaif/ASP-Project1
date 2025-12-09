using Microsoft.EntityFrameworkCore;
using Project1.Models.Domain;

namespace Project1.Data;

public class Project1DbContext : DbContext
{

    public Project1DbContext(DbContextOptions<Project1DbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
}