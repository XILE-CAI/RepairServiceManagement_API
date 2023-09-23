using System.ComponentModel.DataAnnotations.Schema;

namespace RepairServiceManagement.API.Models.RepairRequest
{
    public class GetRepairRequestsDto
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }
        public DateTime RequestDate { get; set; }

        public int CustomerId { get; set; }
    }
}
