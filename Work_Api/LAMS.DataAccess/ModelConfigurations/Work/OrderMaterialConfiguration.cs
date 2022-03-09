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
   public class OrderMaterialConfiguration : EntityTypeConfiguration<OrderMaterialDb>
    {
        public OrderMaterialConfiguration()
        {
            ToTable("OrderMaterial");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.Material)
               .WithMany(t => t.OrderMaterials)
               .HasForeignKey(m => m.IdMaterial)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.Order)
               .WithMany(t => t.OrderMaterials)
               .HasForeignKey(m => m.IdOrder)
               .WillCascadeOnDelete(false);

        }
    }
}
