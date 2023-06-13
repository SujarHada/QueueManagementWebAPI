using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IServiceServices
    {

        public Task<Service> AddServiceAsync(AddService service);
        public Task<IEnumerable<Service>> ListServicesAsync();

        public Task<Service> ViewServiceAsync(Guid ServiceId);

        public Task<Service> UpdateServiceAsync(Service service, UpdateService updateService);
        public Task<Service> ArchiveServiceAsync(Service service);

    }
}
