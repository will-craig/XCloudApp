using Microsoft.EntityFrameworkCore;
using XCloudApp.Domain.Entities;

namespace XCloudApp.DAL;

public class WebAppDbContext(DbContextOptions<WebAppDbContext> options) : DbContext(options)
{
    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Visit>()
                    .HasKey(k => k.Id);
    }
}