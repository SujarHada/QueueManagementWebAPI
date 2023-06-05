using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class AddService
    {
        public Guid ServiceID { get; set; }
        public string ServiceName { get; set; }
        private string Description { get; set; }

    }
}
