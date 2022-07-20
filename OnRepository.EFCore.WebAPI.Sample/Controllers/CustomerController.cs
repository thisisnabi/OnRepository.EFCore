using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnRepository.EFCore.WebAPI.Sample.Models;
using OnRepository.EFCore.WebAPI.Sample.Repositories;

namespace OnRepository.EFCore.WebAPI.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepos;
        private readonly ICustomerKindRepository _customerKindRepos;

        public CustomerController(ICustomerRepository customerRepository, ICustomerKindRepository customerKindRepository)
        {
            _customerRepos = customerRepository;
            _customerKindRepos = customerKindRepository;   
        }

        public IActionResult GetCustomers() 
        {
        
        }



    }
}
