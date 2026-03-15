using Microsoft.EntityFrameworkCore;
using TestDevOpsApp.Domain.Entities;

namespace TestDevOpsApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
