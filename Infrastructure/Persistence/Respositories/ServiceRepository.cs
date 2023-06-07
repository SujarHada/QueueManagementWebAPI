using Application.ServicesApi.Interfaces;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Respositories
{
  
    public class ServiceRepository : IServiceRepository
    {

        private readonly OMSDbContext _dbContext;

        public ServiceRepository(OMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ServiceEnitity> AddServiceAsync(AddService addService)
        {
            var service = new ServiceEnitity()
            {
                ServiceId = Guid.NewGuid(),
                ServiceName = addService.ServiceName,
                ServiceDescription = addService.ServiceDescription,
                IsArchive = false 
            };

            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();


            return service;

        }

        public async Task<IEnumerable<ServiceEnitity>> ListServicesAsync(string? role)
        {
           if (role == "admin")
            {
                return await _dbContext.Services.ToListAsync();
            }

            else
            {
                return await _dbContext.Services.Where(service => !service.IsArchive).ToListAsync();
            }
                
        }

        public async Task<ServiceEnitity> ViewServiceAsync(Guid ServiceId)
        {
           return await _dbContext.Services.FindAsync(ServiceId);
        }


        public async Task<ServiceEnitity> UpdateServiceAsync(ServiceEnitity service, UpdateService updateService)
        {
            service.ServiceName = updateService.ServiceName;
            service.ServiceDescription = updateService.ServiceDescription;

            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<ServiceEnitity> DeleteServiceAsync(ServiceEnitity service)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;

        }

        public async Task<ServiceEnitity> ArchiveServiceAsync(ServiceEnitity Service)
        {
            Service.IsArchive = !Service.IsArchive;

            await _dbContext.SaveChangesAsync();

            return Service;
        }
    }
}
