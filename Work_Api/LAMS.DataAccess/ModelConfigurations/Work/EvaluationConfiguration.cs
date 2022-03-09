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
   public class EvaluationConfiguration : EntityTypeConfiguration<EvaluationDb>
    {
        public EvaluationConfiguration()
        {
            ToTable("Evaluation");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.Order)
               .WithMany(t => t.Evaluations)
               .HasForeignKey(m => m.IdOrder)
               .WillCascadeOnDelete(false);

        }
    }
}