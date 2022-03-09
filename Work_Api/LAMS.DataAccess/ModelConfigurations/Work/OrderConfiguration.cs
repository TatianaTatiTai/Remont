using LAMS.DataAccess.Common.Models.Work;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.ModelConfigurations.Work
{
   public class OrderConfiguration : EntityTypeConfiguration<OrderDb>
    {
        public OrderConfiguration()
        {
            ToTable("Order");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.Orders)
               .HasForeignKey(m => m.UserId)
               .WillCascadeOnDelete(false);

        }
    }
}
