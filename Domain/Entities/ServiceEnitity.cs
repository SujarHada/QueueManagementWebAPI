using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ServiceEnitity
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public bool IsArchive { get; set; }
    }
}
