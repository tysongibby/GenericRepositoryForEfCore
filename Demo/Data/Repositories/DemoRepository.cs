using Demo.Data.Repositories.Interfaces;
using Demo.Data.DataModels;
using SqliteGenericCrudRepository;


namespace Demo.Data.Repositories
{
    public class DemoRepository : GenericRepository<DemoModel>, IDemoModelRepository
    {
        public DemoRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext FlasherContext
        {
            get
            {
                return _context as ApplicationDbContext;
            }
        }

     

    }
}
