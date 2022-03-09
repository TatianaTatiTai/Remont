using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class OrderWorkTypeConfiguration : EntityTypeConfiguration<OrderWorkTypeDb>
    {
        public OrderWorkTypeConfiguration()
        {
            ToTable("OrderWorkType");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.WorkType)
               .WithMany(t => t.OrderWorkTypes)
               .HasForeignKey(m => m.IdWorkType)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.Order)
               .WithMany(t => t.OrderWorkTypes)
               .HasForeignKey(m => m.IdOrder)
               .WillCascadeOnDelete(false);

        }
    }
}
