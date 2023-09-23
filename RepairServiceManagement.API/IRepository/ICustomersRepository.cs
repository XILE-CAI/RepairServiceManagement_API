using RepairServiceManagement.API.Data;

namespace RepairServiceManagement.API.IRepository
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetDetails(int id);
    }
}
