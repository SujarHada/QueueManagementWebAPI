using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ServicesApi.Interfaces;
using Domain.Entities;
using Domain.Models;
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
                ServiceDescription = addService.ServiceDescription
            };

            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();


            return service;

        }

        public async Task<IEnumerable<ServiceEnitity>> ListServicesAsync()
        {
            return await _dbContext.Services.ToListAsync();
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

        public async Task<ServiceEnitity> ArchiveServiceAsync(ServiceEnitity service)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;

        }


    }
}
