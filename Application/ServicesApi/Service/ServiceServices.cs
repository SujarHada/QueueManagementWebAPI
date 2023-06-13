using Application.ApiExceptionHandling.Responses;
using Application.ServicesApi.Interfaces;
using Domain.Entities;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.ServicesApi.Service
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceServices(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ApiExceptionResponse<ServiceEnitity>> AddServiceAsync(AddService service)
        {
            try
            {
                var res = await _serviceRepository.AddServiceAsync(service);
                return new ApiExceptionResponse<ServiceEnitity>(res);
            }

            catch (Exception ex)
            {

                return new ApiExceptionResponse<ServiceEnitity>(ex);

            }
        }

        public async Task<IEnumerable<ServiceEnitity>> ListServicesAsync(string? role)
        {
            return await _serviceRepository.ListServicesAsync(role);
        }

        public async Task<ApiExceptionResponse<ServiceEnitity>> ViewServiceAsync(Guid ServiceId)
        {
            try
            {

                var res = await _serviceRepository.ViewServiceAsync(ServiceId);
                return new ApiExceptionResponse<ServiceEnitity>(res);
            }

            catch (Exception ex)
            {
                return new ApiExceptionResponse<ServiceEnitity>(ex);
            }
        }

        public async Task<ApiExceptionResponse<ServiceEnitity>> UpdateServiceAsync(Guid ServiceId, UpdateService updateService)
        {
            try
            {
                var res = await _serviceRepository.UpdateServiceAsync(ServiceId, updateService);
                return new ApiExceptionResponse<ServiceEnitity>(res);
            }

            catch (Exception ex)
            {
                return new ApiExceptionResponse<ServiceEnitity>(ex);
            }
        }
        public async Task<ApiExceptionResponse<ServiceEnitity>> DeleteServiceAsync(Guid ServiceId)
        {
            try
            {
                var res = await _serviceRepository.DeleteServiceAsync(ServiceId);
                return new ApiExceptionResponse<ServiceEnitity>(res);

            }


            catch (Exception ex)
            {
                return new ApiExceptionResponse<ServiceEnitity>(ex);
            }
        }

        public async Task<ApiExceptionResponse<ServiceEnitity>> ArchiveServiceAsync(Guid ServiceId)
        {
            try
            {
                var res = await _serviceRepository.ArchiveServiceAsync(ServiceId);
                return new ApiExceptionResponse<ServiceEnitity>(res);
            }

            catch (Exception ex)
            {
                return new ApiExceptionResponse<ServiceEnitity>(ex);
            }
        }

        public async Task<IEnumerable<ServiceEnitity>> SearchAsync(string? name)
        {
            return await _serviceRepository.SearchAsync(name);
        }
    }
}
