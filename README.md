# OnRepository.EFCore

> The repository and unit of work patterns are intended to create an abstraction layer between the data access layer and the business logic layer of an application. Implementing these patterns can help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development (TDD). [more](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)

This package helps you to easily implement Repository Pattern in your programs.

## Authors

- [@thisisnabi](https://www.github.com/thisisnabi)



## Features
- Use EntityBase for your entities
- You can use Repository & ReadOnlyRepository
- Same common method likes Read,Delete,List,Add,Update and etc.
- You can use IUnitOfWork patterns
- Use Transactional actions



## Install

Install with Package Manager Console  

```bash
  Install-Package OnRepository.EFCore
```


## Extend/ReposDbContext
For use custom DbContext you can inherit from ReposDbContext
 
```csharp
// you must inherit, if you want use IUnitOfWork & Transactional options
public class AppDbContext : ReposDbContext
```




