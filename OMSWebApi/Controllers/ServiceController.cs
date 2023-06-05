using Microsoft.AspNetCore.Mvc;

namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
     

       public HomeController()
      {
        
      }
   
            [HttpPost]

        public Task<object?> AddService()
        {
            return Task.FromResult<object?>(null);
        }

    }

}