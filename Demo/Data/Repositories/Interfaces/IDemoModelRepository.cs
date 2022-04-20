using Demo.Data.DataModels;
using GenericRepositoryForEfCore.Interfaces;
using System.Threading.Tasks;

namespace Demo.Data.Repositories.Interfaces
{
    public interface IDemoModelRepository : IGenericRepository<DemoModel>
    {
       
    }
}