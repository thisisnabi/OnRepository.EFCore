using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnRepository.EFCore.WebAPI.Sample.Data;
using OnRepository.EFCore.WebAPI.Sample.Models;
using OnRepository.EFCore.WebAPI.Sample.Repositories;

namespace OnRepository.EFCore.WebAPI.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customers;
        private readonly ICustomerKindRepository _kinds;

        public CustomerController(ICustomerRepository customerRepository, 
            ICustomerKindRepository customerKindRepository
            )
        {
            _customers = customerRepository;
            _kinds = customerKindRepository;
        }

        // Full Access Repository
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customers
                .ListAsync(cs => cs.Name.StartsWith("Nabi"));

            return Ok(result);
        }

        public async Task<ActionResult<Customer>> CreateCustomer(string name,string address,int kindId) 
        {
            var newCustomer = await _customers.AddAsync(new Customer
            {
                Name = name,
                Address = address,
                KindId = kindId
            });

            await _customers.UnitOfWork.SaveChangesAsync();

            return Ok(newCustomer);
        }

        public async Task<ActionResult<Customer>> CreateCustomers(string name, string address, int kindId)
        {
            // create your Transaction Scope, you can pass Isolation Level
            using(var transactionScope = await _customers.UnitOfWork.BeginTransactionAsync())
            {
                if (transactionScope is null)
                    return BadRequest("Can't take a Trasaction Scope.");

                for (int i = 0; i < 10; i++)
                {
                    await _customers.AddAsync(new Customer
                    {
                        Name = name,
                        Address = address,
                        KindId = kindId
                    });
                }
                 
                try
                {
                    await _customers.UnitOfWork.SaveChangesAsync();
                    await transactionScope.CommitAsync();
                    return Ok("Trasaction was done");
                }
                catch (Exception)
                {
                    await transactionScope.RollbackAsync();
                    return BadRequest("Transaction was rollbacked.");
                }
            }
       
        }


        // readOnlyRepository
        public async Task<IActionResult> GetCustomerKinds() 
            => Ok(await _kinds.ListAsync());
 
    }
}
