using Data.Repositories.Interfaces;
using Data.DataModels;


namespace Data.Repositories
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
