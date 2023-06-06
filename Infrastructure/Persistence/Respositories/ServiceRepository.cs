using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
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


        public async Task<Service> AddServiceAsync(AddService addService)
        {
            var service = new Service()
            {
                ServiceId = Guid.NewGuid(),
                ServiceName = addService.ServiceName,
                ServiceDescription = addService.ServiceDescription
            };

            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();


            return service;

        }

        public async Task<IEnumerable<Service>> ListServicesAsync()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<Service> ViewServiceAsync(Guid ServiceId)
        {
           return await _dbContext.Services.FindAsync(ServiceId);
        }


        public async Task<Service> UpdateServiceAsync(Service service, UpdateService updateService)
        {
            service.ServiceName = updateService.ServiceName;
            service.ServiceDescription = updateService.ServiceDescription;

            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<Service> ArchiveServiceAsync(Service service)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;

        }


    }
}
