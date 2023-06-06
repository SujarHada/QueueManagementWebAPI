using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence
{
    public class OMSDbContext : DbContext
    {
        public OMSDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Service> Services { get; set; }
       
    }
}
