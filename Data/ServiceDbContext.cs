using Microsoft.EntityFrameworkCore;
using OMSWebApi.Entity;


namespace OMSWebApi.Data
{



  public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions options) : base(options)
    {
    }

public DbSet<Service> Services {get; set;}


}

}
