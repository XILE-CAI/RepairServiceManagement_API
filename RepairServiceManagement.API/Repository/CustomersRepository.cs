using Microsoft.EntityFrameworkCore;
using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.IRepository;

namespace RepairServiceManagement.API.Repository
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        private readonly RepairServiceDbContext _context;

        public CustomersRepository(RepairServiceDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Customer> GetDetails(int id)
        {
            return await _context.Customers.Include(c => c.RepairRequests)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
