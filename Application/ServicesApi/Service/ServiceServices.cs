using Application.ServicesApi.Interfaces;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicesApi.Service
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceServices(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ServiceEnitity> AddServiceAsync(AddService service)
        {
            return await _serviceRepository.AddServiceAsync(service);
        }

        public async Task<IEnumerable<ServiceEnitity>> ListServicesAsync()
        {
            return await _serviceRepository.ListServicesAsync();
        }

        public async Task<ServiceEnitity> ViewServiceAsync(Guid ServiceId)
        {
            return await _serviceRepository.ViewServiceAsync(ServiceId);
        }

        public async Task<ServiceEnitity> UpdateServiceAsync(ServiceEnitity service, UpdateService updateService)
        {
            return await _serviceRepository.UpdateServiceAsync(service, updateService);
        }
        public async Task<ServiceEnitity> ArchiveServiceAsync(ServiceEnitity service)
        {
            return await _serviceRepository.ArchiveServiceAsync(service);
        }
    }
}
