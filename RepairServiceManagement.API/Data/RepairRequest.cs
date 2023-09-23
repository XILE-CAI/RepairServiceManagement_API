using System.ComponentModel.DataAnnotations.Schema;

namespace RepairServiceManagement.API.Data
{
    public class RepairRequest
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }
    }
}
