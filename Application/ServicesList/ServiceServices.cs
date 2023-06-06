using Application.Interfaces;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceServices(IServiceRepository serviceRepository)
        {
          _serviceRepository = serviceRepository;
        }
        public async Task<Service> AddServiceAsync(AddService service)
        {
            return await _serviceRepository.AddServiceAsync(service);
        }
    }
}
