using LAMS.DataAccess.Common.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace LAMS.DataAccess.ModelConfigurations.Auth
{
    class RoleConfiguration : EntityTypeConfiguration<RoleDb>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");

            HasKey(c =>  c.Id );

            //HasMany(x => x.Users)
            //    .WithOptional()
            //    .HasForeignKey(x => x.RoleId);
        }
    }
}
