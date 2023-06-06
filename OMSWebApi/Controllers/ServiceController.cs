using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces;

namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {

        private readonly IServiceServices _serviceServices; 
       

       public ServiceController(IServiceServices serviceServices)
      {
            _serviceServices = serviceServices;
          
      }


        [HttpPost]
       public async Task<IActionResult> AddService(AddService addservice)
       {
            
            var add = await _serviceServices.AddServiceAsync(addservice);

            return Ok(add);
       }

    }

}