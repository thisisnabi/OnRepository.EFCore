using OnRepository.EFCore.WebAPI.Sample.Models;

namespace OnRepository.EFCore.WebAPI.Sample.Repositories;

public interface ICustomerKindRepository : IReadOnlyRepository<CustomerKind>
{

    Task<List<CustomerKind>?> GetFromKind(int kindId);
}
