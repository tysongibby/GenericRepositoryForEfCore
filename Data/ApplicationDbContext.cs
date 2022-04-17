using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data.DataModels;
using Data.EntityConfigurations;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public IConfiguration Configuration { get; }       
        public DbContextOptions<ApplicationDbContext> Options { get; }
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Configuration = configuration;                   
        }
       
        public virtual DbSet<DemoModel> Categories { get; set; }
        
        //public void ConfigureServices(IServiceCollection services)
        //{
        ////  https://www.tektutorialshub.com/entity-framework-core/ef-core-dbcontext/
        //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("ApplicationDb")));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<DemoModel>(new DemoModelConfig());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // https://csharp.hotexamples.com/examples/-/DbContextOptionsBuilder/-/php-dbcontextoptionsbuilder-class-examples.html
        //    base.OnConfiguring(optionsBuilder);
            
        //}
    }
}
