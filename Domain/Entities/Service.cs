using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}
