using BILET_website.Models;
using Microsoft.EntityFrameworkCore;

namespace BILET_website.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<Portfolio>Portfolios { get; set; }
    }
}
