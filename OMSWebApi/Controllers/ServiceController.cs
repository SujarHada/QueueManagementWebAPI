using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.ServicesApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;
using Infrastructure.Persistence;


namespace OMSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceController : Controller
    {

        private readonly IServiceServices _serviceServices;
        private readonly OMSDbContext _dbContext;


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
            if (role == "admin" || role == "outpatient" || role == "member")
            {
                return Ok(await _serviceServices.ListServicesAsync(role));
            }

            else
            {
                return BadRequest("You cannot access this feature");
            }
        }

        [HttpGet]
        [Route("{ServiceId:guid}")]

        public async Task<IActionResult> ViewService([FromRoute] Guid ServiceId)
        {
            var role = User.FindFirst("Role")?.Value;
            if (role == "admin" || role == "outpatient" || role == "member")
            {

                return Ok(await _serviceServices.ViewServiceAsync(ServiceId));
            }

            else
            {
                return BadRequest("You cannot access this feature");
            }
        }


        [HttpPut]
        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> UpdateService([FromRoute] Guid ServiceId, UpdateService updateService)
        {

            var role = User.FindFirst("Role")?.Value;
            if (role == "admin")
            {
                return Ok(await _serviceServices.UpdateServiceAsync(ServiceId, updateService));
            }

            else
            {
                return BadRequest("Only Admin can update services");
            }
        }



        [HttpDelete]
        [Route("{ServiceId:guid}")]
        public async Task<IActionResult> DeleteService([FromRoute] Guid ServiceId)
        {
            var role = User.FindFirst("Role")?.Value;
            if (role == "admin")
            {
                return Ok(await _serviceServices.DeleteServiceAsync(ServiceId));
            }

            else
            {
                return BadRequest("Only Admin can delete services");
            }
        }


        [HttpPut]
        [Route("Archive/{ServiceId:guid}")]
        public async Task<IActionResult> ArchiveService([FromRoute] Guid ServiceId)
        {
            var role = User.FindFirst("Role")?.Value;
           
                if (role == "admin")
            {

         
                return Ok(await _serviceServices.ArchiveServiceAsync(ServiceId));

            }

            else
            {
                return BadRequest("Only Admin can archive services");
            }


        }

        [HttpGet("Searches")]
        public async Task<ActionResult> SearchAsync(string ServiceName)
        {
            return Ok(await _serviceServices.SearchAsync(ServiceName));
        }



    }

}