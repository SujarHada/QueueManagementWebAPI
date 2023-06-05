using Microsoft.AspNetCore.Mvc;

namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {


        public ServiceController()
      {
        
      }
   
            [HttpPost]

        public Task<object?> AddService()
        {
            
        }

    }

}