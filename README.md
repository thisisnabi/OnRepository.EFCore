# OnRepository.EFCore

> The repository and unit of work patterns are intended to create an abstraction layer between the data access layer and the business logic layer of an application. Implementing these patterns can help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development (TDD). [more](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)

This package helps you to easily implement Repository Pattern in your programs.

## Authors

- [@thisisnabi](https://www.github.com/thisisnabi)



## Features
- Use EntityBase for your entities
- You can use Repository & ReadOnlyRepository
- Same common method likes Read, Delete, List, Add, Update and etc.
- You can use IUnitOfWork patterns
- Use Transactional actions



## Install

Install with Package Manager Console  

```bash
  Install-Package OnRepository.EFCore
```


## Extend/ Same base class you can use

Using base classes makes it easier for you to implement the pattern
 
```csharp

// DbContext
// you must inherit, if you want use IUnitOfWork & Transactional options
public class AppDbContext : ReposDbContext
```

 
```csharp
// Models
// Context Entities must inherit from EntityBase

public class CustomerKind : EntityBase
{
    // your fields
}

public class Customer : EntityBase
{
    // your fields
}
```

```csharp
// Repository Interfaces
// You have 2 types of Repository, such as ReadOnlyRepository and Full-Access Repositoy which you can inherit from those.

// IReadOnlyRepository - includes just reading methods 
public interface ICustomerKindRepository : IReadOnlyRepository<CustomerKind>
{
    // you can add custom methods
    // but be careful, just read!
    Task<List<CustomerKind>> GetFromKind(int kindId);
}

// IRepository - You can use CRUD methods
public interface ICustomerRepository : IRepository<Customer>
{
    // you can add custom methods
}
```


```csharp
// Repository Classes

// ReadOnlyRepository - includes just reading methods 
 public class CustomerKindRepository : ReadOnlyRepository<CustomerKind>, ICustomerKindRepository
 {
    // you must pass your app db context to repository base
    public CustomerKindRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
    
    // your custom method
    public async Task<List<CustomerKind>?> GetFromKind(int kindId) 
        => await ListAsync(kind => kind.Id >= kindId);
 }

// IRepository - You can use CRUD methods
public interface ICustomerRepository : IRepository<Customer>
{
    // you can add custom methods
}
```


