using RepairServiceManagement.API.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairServiceManagement.API.Models.RepairRequest
{
    public class CreateRepairRequestDto
    {
        [Required]
        public string DeviceType { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
