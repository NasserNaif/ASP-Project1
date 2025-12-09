using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project1.Data;

public class Project1AuthDbContext : IdentityDbContext
{

    public Project1AuthDbContext(DbContextOptions<Project1AuthDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var readerRoleId = "189679fd-ff76-4c0e-9210-3cc91a76c48f";
        var writerRoleId = "9c971928-9d8f-4abd-a4a1-c3c6918ff8ed";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                Name = "Reader",
                NormalizedName = "READER",
                ConcurrencyStamp = readerRoleId
            },
            new IdentityRole
            {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName = "WRITER",
                ConcurrencyStamp = writerRoleId
            },
        };
        
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}