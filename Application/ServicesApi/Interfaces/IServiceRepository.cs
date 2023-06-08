using Domain.Entities;
using Domain.Models;

namespace Application.ServicesApi.Interfaces
{
    public interface IServiceRepository
    {
        public Task<ServiceEnitity> AddServiceAsync(AddService service);
        public Task<IEnumerable<ServiceEnitity>> ListServicesAsync(string? role);

        public Task<ServiceEnitity> ViewServiceAsync(Guid ServiceId);

        public Task<ServiceEnitity> UpdateServiceAsync(Guid ServiceId, UpdateService updateService);
        public Task<ServiceEnitity> DeleteServiceAsync(Guid ServiceId );

        public Task<ServiceEnitity> ArchiveServiceAsync(Guid ServiceId);

    }
}
