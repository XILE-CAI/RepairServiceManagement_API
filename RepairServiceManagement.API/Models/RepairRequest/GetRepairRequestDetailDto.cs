using System.ComponentModel.DataAnnotations.Schema;

namespace RepairServiceManagement.API.Models.RepairRequest
{
    public class GetRepairRequestDetailDto
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }

        public int CustomerId { get; set; }
    }
}
