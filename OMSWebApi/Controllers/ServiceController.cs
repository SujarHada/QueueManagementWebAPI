using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Application.Interfaces;
using Infrastructure.Persistence.Respositories;

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
            
 

            return Ok(await _serviceServices.AddServiceAsync(addservice));
       }

        [HttpGet]

        public async Task<IActionResult> ListServices()
        {
            return Ok(await _serviceServices.ListServicesAsync());
        }

        [HttpGet]
        [Route("{ServiceId:guid}")]

        public async Task<IActionResult> ViewService([FromRoute] Guid ServiceId)
        {
            return Ok(await _serviceServices.ViewServiceAsync(ServiceId));
        }


        [HttpPut]
        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> UpdateService([FromRoute] Guid ServiceId , UpdateService updateService)
        {
            var service = await _serviceServices.ViewServiceAsync(ServiceId);
            if (service == null)
                return BadRequest("Service Not Found");
            return Ok(await _serviceServices.UpdateServiceAsync(service , updateService));
        }

        [HttpDelete]

        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> ArchiveService([FromRoute] Guid ServiceId)
        {
            var service = await _serviceServices.ViewServiceAsync(ServiceId);
            if (service == null)
                return BadRequest("Service Not Found");
            return Ok(await _serviceServices.ArchiveServiceAsync(service));
        }




    }

}