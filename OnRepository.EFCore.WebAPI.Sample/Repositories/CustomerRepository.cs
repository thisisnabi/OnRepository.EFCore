using OnRepository.EFCore.WebAPI.Sample.Data;
using OnRepository.EFCore.WebAPI.Sample.Models;

namespace OnRepository.EFCore.WebAPI.Sample.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
