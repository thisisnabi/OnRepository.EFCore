using OnRepository.EFCore.WebAPI.Sample.Data;
using OnRepository.EFCore.WebAPI.Sample.Models;

namespace OnRepository.EFCore.WebAPI.Sample.Repositories
{
    public class CustomerKindRepository : ReadOnlyRepository<CustomerKind>, ICustomerKindRepository
    {
        public CustomerKindRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<CustomerKind>?> GetFromKind(int kindId) 
            => await ListAsync(kind => kind.Id >= kindId);
        
    }
}
