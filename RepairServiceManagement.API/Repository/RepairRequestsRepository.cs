using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.IRepository;

namespace RepairServiceManagement.API.Repository
{
    public class RepairRequestsRepository : GenericRepository<RepairRequest>, IRepairRequestsRepository
    {
        public RepairRequestsRepository(RepairServiceDbContext context) : base(context)
        {
        }
    }
}
