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
    }
}
