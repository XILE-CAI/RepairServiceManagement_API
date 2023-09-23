using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairServiceManagement.API.Models.RepairRequest
{
    public class UpdateRepairRequestDto
    {
        public int Id { get; set; }

        public string DeviceType { get; set; }
        public string Description { get; set; }


        [Required]
        public int CustomerId { get; set; }
    }
}
