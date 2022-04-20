using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.DataModels;

namespace Demo.Data.EntityConfigurations
{
    class DemoModelConfig : IEntityTypeConfiguration<DemoModel>
    {
        public void Configure(EntityTypeBuilder<DemoModel> builder)
        {            
            builder.HasData(
                    new List<DemoModel>
                    {                        
                        new DemoModel{ Id = 1, Name = "DemoModel 1"},
                        new DemoModel{ Id = 2, Name = "DemoModel 2"},
                        new DemoModel{ Id = 3, Name = "DemoModel 3"},
                        new DemoModel{ Id = 4, Name = "DemoModel 4"},
                        new DemoModel{ Id = 5, Name = "DemoModel 5"}
                    }
                );

        }

    }
}
