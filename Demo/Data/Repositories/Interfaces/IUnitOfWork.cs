using System;
using System.Threading.Tasks;

namespace Demo.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {        
        IDemoModelRepository DemoModels { get; }

        int UpdateDb();

        Task<int> UpdateDbAsync();

    }
}
