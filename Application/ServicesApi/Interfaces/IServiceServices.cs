using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Entities;

namespace Application.ServicesApi.Interfaces
{
    public interface IServiceServices
    {

        public Task<ServiceEnitity> AddServiceAsync(AddService service);
        public Task<IEnumerable<ServiceEnitity>> ListServicesAsync();

        public Task<ServiceEnitity> ViewServiceAsync(Guid ServiceId);

        public Task<ServiceEnitity> UpdateServiceAsync(ServiceEnitity service, UpdateService updateService);
        public Task<ServiceEnitity> ArchiveServiceAsync(ServiceEnitity service);

    }
}
