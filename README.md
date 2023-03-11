# Generic Repository for Entity Framework Core - BETA

Generic repository class for Entity Framework Core.  "GenericRepository" Can be inherited by any data model repository to instantly add basic functions such as create, read, update, delete, etc..

Create your own interface and have it inherit from "IGenericRepsitory" to use dependency injection and add your own custom function. Then have your repositry inherit your interface after inherting "GenericRepository"  See examples below.

Based on .NET 6 and EF Core. *This project is in BETA* - TESTING NOT COMPLETE ON ASYNCHRONOUS METHODS

package install:
```
dotnet add package GenericRepositoryForEfCore
```
Example implementation:

```
using Demo.UltiLuvData.Repositories.Interfaces;
using Demo.UltiLuvData.DataModels;
using GenericRepositoryForEfCore;

namespace Demo.UltiLuvData.Repositories
{
    public class DemoRepository : GenericRepository<DemoModel>, IDemoModelRepository
    {
        public DemoRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationContext
        {
            get
            {
                return _context as ApplicationDbContext;
            }
        }    
         // add additional functionality here you stubbed in and inherited from your interface
    }
}
```
```
using Demo.UltiLuvData.DataModels;
using GenericRepositoryForEfCore.Interfaces;
using System.Threading.Tasks;

namespace Demo.UltiLuvData.Repositories.Interfaces
{
    public interface IDemoModelRepository : IGenericRepository<DemoModel>
    {
       // stub additional functionality here to be inherited by your repository
    }
}
```
