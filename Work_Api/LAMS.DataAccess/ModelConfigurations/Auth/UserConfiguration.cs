using LAMS.DataAccess.Common.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace LAMS.DataAccess.ModelConfigurations.Auth
{
    class UserConfiguration : EntityTypeConfiguration<UserDb>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            HasRequired(m => m.Role)
               .WithMany(t => t.Users)
               .HasForeignKey(m =>  m.RoleId)
               .WillCascadeOnDelete(false);

        }
    }
}
