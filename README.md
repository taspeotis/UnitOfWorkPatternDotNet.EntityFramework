## UnitOfWorkPatternDotNet.EntityFramework

Two (extremely) lightweight UoW implementations for Entity Framework.

### License

*UnitOfWorkPatternDotNet.EntityFramework* is licensed under the [*Microsoft Public License (MS-PL)*](http://www.microsoft.com/en-us/openness/licenses.aspx).

### Getting Started

[*UnitOfWorkPatternDotNet.EntityFramework* is available on NuGet](https://www.nuget.org/packages/UnitOfWorkPatternDotNet.EntityFramework).

You'll probably want [*RepositoryPatternDotNet.EntityFramework*](https://github.com/taspeotis/RepositoryPatternDotNet.EntityFramework) as well. Among other things, it can help with unit testing. Read about it below.

### Usage

*UnitOfWorkPatternDotNet.EntityFramework* implements *UnitOfWorkPatternDotNet* for Entity Framework.

You can use either `EntityFrameworkUnitOfWork` (which implements `IUnitOfWork`) or `EntityFrameworkAsyncUnitOfWork` (which implements `IAsyncUnitOfWork`).

    public class IApplicationContext : IAsyncUnitOfWork
    {
        DbSet<Cat> Cats { get; }
        DbSet<Dog> Dogs { get; }
    }

    public class ApplicationContext : EntityFrameworkAsyncUnitOfWork, IApplicationContext
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ...
        }
    }

Simply use `IApplicationContext` wherever you need to perform data access:

    using (IApplicationContext applicationContext = GetApplicationContext())
    {
        Console.WriteLine("I have {0} animals",
            applicationContext.Cats.Count() + applicationContext.Dogs.Count());

        // ... insert/update/delete animals

        await applicationContext.CommitAsync();
    }

### Unit Testing

Come time for unit testing, you may have difficulty faking `DbSet<T>`. Instead of using `DbSet<T>` on your context's interface, you can add a layer of abstraction. A generic repository pattern works well in these circumstances. 

[*RepositoryPatternDotNet*](https://github.com/taspeotis/RepositoryPatternDotNet) provides this abstraction, and [*RepositoryPatternDotNet.EntityFramework*](https://github.com/taspeotis/RepositoryPatternDotNet.EntityFramework) provides an implementation for Entity Framework.

You can also use your own abstractions and implementations with *UnitOfWorkPatternDotNet.EntityFramework*.