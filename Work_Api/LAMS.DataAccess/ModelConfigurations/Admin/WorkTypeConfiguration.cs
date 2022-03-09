using LAMS.DataAccess.Common.Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Admin
{
   public class WorkTypeConfiguration : EntityTypeConfiguration<WorkTypeDb>
    {
        public WorkTypeConfiguration()
        {
            ToTable("WorkType");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
