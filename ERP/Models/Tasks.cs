using ERP.Models.Enums;
using System.Security.Cryptography.X509Certificates;

namespace ERP.Models
{
    public class Tasks
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Data { get; set; }

        public StatusTarefa status {  get; set; }

        public string? Description { get; set; }
    }
}
