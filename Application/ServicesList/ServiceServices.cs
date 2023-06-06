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

        public async Task<IEnumerable<Service>> ListServicesAsync()
        {
            return await _serviceRepository.ListServicesAsync();
        }

        public async Task<Service> ViewServiceAsync(Guid ServiceId)
        {
            return await _serviceRepository.ViewServiceAsync(ServiceId);
        }

        public async Task<Service> UpdateServiceAsync(Service service, UpdateService updateService)
        {
            return await _serviceRepository.UpdateServiceAsync(service, updateService);
        }
        public async Task<Service> ArchiveServiceAsync(Service service)
        {
            return await _serviceRepository.ArchiveServiceAsync(service);
        }
    }
}
