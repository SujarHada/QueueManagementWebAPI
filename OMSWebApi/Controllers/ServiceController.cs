using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.ServicesApi.Interfaces;
using Microsoft.AspNetCore.Authorization;



namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            var role = User.FindFirst("Role")?.Value;
            if (role == "admin")
            {
                return Ok(await _serviceServices.AddServiceAsync(addservice));
            }

            else
            {
                return BadRequest("Only Admin can create services");
            }

        }

        [HttpGet]

        public async Task<IActionResult> ListServices()
        {
            var role = User.FindFirst("Role")?.Value;
            return Ok(await _serviceServices.ListServicesAsync(role));
        }

        [HttpGet]
        [Route("{ServiceId:guid}")]

        public async Task<IActionResult> ViewService([FromRoute] Guid ServiceId)
        {
            return Ok(await _serviceServices.ViewServiceAsync(ServiceId));
        }


        [HttpPut]
        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> UpdateService([FromRoute] Guid ServiceId, UpdateService updateService)
        {
            var service = await _serviceServices.ViewServiceAsync(ServiceId);
            if (service == null)
                return BadRequest("Service Not Found");
            return Ok(await _serviceServices.UpdateServiceAsync(service, updateService));
        }



        [HttpDelete]

        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> DeleteService([FromRoute] Guid ServiceId)
        {
            var service = await _serviceServices.ViewServiceAsync(ServiceId);
            if (service == null)
                return BadRequest("Service Not Found");
            return Ok(await _serviceServices.DeleteServiceAsync(service));
        }


        [HttpPut]
        [Route("Archive/{ServiceId:guid}")]
        public async Task<IActionResult> ArchiveService([FromRoute] Guid ServiceId)
        {
            var service = await _serviceServices.ViewServiceAsync(ServiceId);
            if (service == null)
                return BadRequest("Service Not Found");
            return Ok(await _serviceServices.ArchiveServiceAsync(service));
        }



    }

}