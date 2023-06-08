using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class OMSDbContext : DbContext
    {
        public OMSDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ServiceEnitity> Services { get; set; }

        public DbSet<User> Users { get; set; }
       
    }
}
