using Domain.Models;
using Domain.Entities;
using Application.ApiExceptionHandling.Responses;


namespace Application.ServicesApi.Interfaces
{
    public interface IServiceServices
    {

        public Task<ApiExceptionResponse<ServiceEnitity>> AddServiceAsync(AddService service);
        public Task<IEnumerable<ServiceEnitity>> ListServicesAsync(string? role);

        public Task<IEnumerable<ServiceEnitity>> SearchAsync(string? name);

        public Task<ApiExceptionResponse<ServiceEnitity>> ViewServiceAsync(Guid ServiceId);

        public Task<ApiExceptionResponse<ServiceEnitity>> UpdateServiceAsync(Guid ServiceId, UpdateService updateService);
        public Task<ApiExceptionResponse<ServiceEnitity>> DeleteServiceAsync(Guid ServiceId);
        public Task<ApiExceptionResponse<ServiceEnitity>> ArchiveServiceAsync(Guid ServiceId);
    }
}
