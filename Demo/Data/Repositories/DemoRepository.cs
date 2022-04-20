using Demo.Data.Repositories.Interfaces;
using Demo.Data.DataModels;
using GenericRepositoryForEfCore;


namespace Demo.Data.Repositories
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

     

    }
}
