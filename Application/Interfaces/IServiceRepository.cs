using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceRepository
    {
        public Task<Service> AddServiceAsync(AddService service);
    }
}
