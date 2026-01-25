using Microsoft.EntityFrameworkCore;
using XCloudApp.Domain.Entities;

namespace XCloudApp.DAL;

public class WebAppDbContext(DbContextOptions<WebAppDbContext> options) : DbContext(options)
{
    public DbSet<Visit> Visits { get; set; }
    
    
}