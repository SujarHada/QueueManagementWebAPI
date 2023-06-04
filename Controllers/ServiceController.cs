using Microsoft.AspNetCore.Mvc;
using OMSWebApi.Entity;
using OMSWebApi.Data;
using OMSWebApi.Models;
namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
      private readonly ServiceDbContext _dbContext;

       public HomeController(ServiceDbContext dbContext)
      {
        _dbContext = dbContext;
      }

   
            [HttpPost]

            public async Task<IActionResult> AddService(AddService addService)
        {
                var service = new Service()
                {
                   ServiceId = Guid.NewGuid(),
                   ServiceName = addService.ServiceName,
                   Description = addService.Description
                };

                await _dbContext.Services.AddAsync(service);
                await _dbContext.SaveChangesAsync();

                return Ok(service);
            }

    }

}