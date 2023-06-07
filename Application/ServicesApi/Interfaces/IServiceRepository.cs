using Domain.Entities;
using Domain.Models;

namespace Application.ServicesApi.Interfaces
{
    public interface IServiceRepository
    {
        public Task<ServiceEnitity> AddServiceAsync(AddService service);
        public Task<IEnumerable<ServiceEnitity>> ListServicesAsync(string? role);

        public Task<ServiceEnitity> ViewServiceAsync(Guid ServiceId);

        public Task<ServiceEnitity> UpdateServiceAsync(ServiceEnitity service , UpdateService updateService);
        public Task<ServiceEnitity> DeleteServiceAsync(ServiceEnitity Service);

        public Task<ServiceEnitity> ArchiveServiceAsync(ServiceEnitity Service);

    }
}
