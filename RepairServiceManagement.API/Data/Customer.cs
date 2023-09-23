using System;

namespace RepairServiceManagement.API.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //lazy loading enabled by marking as virtual
        public virtual IList<RepairRequest> RepairRequests { get; set; }
    }
}
