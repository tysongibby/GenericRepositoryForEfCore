using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {        
        IDemoModelRepository DemoModels { get; }

        int UpdateDb();

        Task<int> UpdateDbAsync();

    }
}
