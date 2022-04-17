using Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            DemoModels = new DemoRepository(_context);
        }       

        public IDemoModelRepository DemoModels { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public int UpdateDb()
        {            
            return _context.SaveChanges();
        }

        public Task<int> UpdateDbAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
