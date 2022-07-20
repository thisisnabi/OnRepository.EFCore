﻿using OnRepository.EFCore.WebAPI.Sample.Data;
using OnRepository.EFCore.WebAPI.Sample.Models;

namespace OnRepository.EFCore.WebAPI.Sample.Repositories
{
    public class CustomerKindRepository : ReadOnlyRepository<CustomerKind>, ICustomerKindRepository
    {
        public CustomerKindRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
