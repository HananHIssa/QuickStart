using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickStart.DAL.Data.Models;

namespace QuickStart.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Services> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Item> Items { get; set; }

    }

}
