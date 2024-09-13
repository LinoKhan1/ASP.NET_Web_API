using Microsoft.EntityFrameworkCore;
using restful_api.Core.Entities;

namespace restful_api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet Products
        public DbSet<Product> Products { get; set; }    
    }
}
