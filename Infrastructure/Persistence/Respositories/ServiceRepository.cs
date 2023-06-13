using Application.ApiExceptionHandling.Exceptions;
using Application.ServicesApi.Interfaces;
using Application.ServicesApi.Service;
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
            var Namechecker = await _dbContext.Services.FirstOrDefaultAsync(u => u.ServiceName == addService.ServiceName );
            var DesChecker = await _dbContext.Services.FirstOrDefaultAsync(u=> u.ServiceDescription == addService.ServiceDescription);

            if (Namechecker == null)
            {
              if (DesChecker == null)
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

                throw new DuplicateServices(addService.ServiceName , addService.ServiceDescription);

            }

            throw new DuplicateServices(addService.ServiceName);




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
            ServiceEnitity service =  await _dbContext.Services.FindAsync(ServiceId);

            if (service == null)
                throw new ServiceNotFound();

            return service;
        }


        public async Task<ServiceEnitity> UpdateServiceAsync(Guid ServiceId, UpdateService updateService)
        { 
            ServiceEnitity service = await _dbContext.Services.FindAsync(ServiceId);
            var changeChecker = await _dbContext.Services.FirstOrDefaultAsync(u => u.ServiceName == service.ServiceName && u.ServiceDescription == service.ServiceDescription);
            var nameChecker = await _dbContext.Services.FirstOrDefaultAsync(u => u.ServiceName == updateService.ServiceName);
            var descriptionChecker = await _dbContext.Services.FirstOrDefaultAsync(u => u.ServiceDescription == updateService.ServiceDescription);

            if (nameChecker == null)
            {
                if (descriptionChecker == null)
                {

                    if (changeChecker.ServiceName != updateService.ServiceName || changeChecker.ServiceDescription != updateService.ServiceDescription)
                    {

                        service.ServiceName = updateService.ServiceName;
                        service.ServiceDescription = updateService.ServiceDescription;

                        await _dbContext.SaveChangesAsync();
                        return service;

                    }

                    throw new NoUpdatesMade(service.ServiceName);
                }

                throw new DuplicateServices(updateService.ServiceName, updateService.ServiceDescription);

            }

            throw new DuplicateServices(updateService.ServiceName);


        }

        public async Task<ServiceEnitity> DeleteServiceAsync(Guid ServiceId)
        {
            ServiceEnitity service = await _dbContext.Services.FindAsync(ServiceId);
            if (service == null)
                throw new ServiceNotFound();

            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;

        }

        public async Task<ServiceEnitity> ArchiveServiceAsync(Guid ServiceId)
        {
            ServiceEnitity service = await _dbContext.Services.FindAsync(ServiceId);

            if (service == null)
                throw new ServiceNotFound();


            service.IsArchive = !service.IsArchive;

            await _dbContext.SaveChangesAsync();

            return service;
        }

        public async Task<IEnumerable<ServiceEnitity>> SearchAsync(string? name)
        {
            IQueryable<ServiceEnitity> query = _dbContext.Services;

            var query = _dbContext.Services.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.ServiceName.Contains(name));
                query = query.OrderBy(a => CalculateSimilarity(a.ServiceName, name));
            }
            return await query.ToListAsync();
        }
    }
}
