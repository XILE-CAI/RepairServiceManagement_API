using RepairServiceManagement.API.Models.RepairRequest;

namespace RepairServiceManagement.API.Models.Customer
{
    public class GetCustomerDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public IList<GetRepairRequestDetailDto> RepairRequests { get; set; }
    }
}
