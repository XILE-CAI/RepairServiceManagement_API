using Microsoft.EntityFrameworkCore;

namespace RepairServiceManagement.API.Data
{
    public class RepairServiceDbContext : DbContext
    {
        public RepairServiceDbContext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
    }
}
