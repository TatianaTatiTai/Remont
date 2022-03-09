
using LAMS.DataAccess.Common.Models.Admin;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Models.Work;
using LAMS.DataAccess.ModelConfigurations.Admin;
using LAMS.DataAccess.ModelConfigurations.Auth;
using LAMS.DataAccess.ModelConfigurations.Work;
using System.Data.Entity;

namespace LAMS.DataAccess.Contexts
{
 
    public class DocContext : DbContext
    {
        public DocContext() : base("Connection") { }
        public DocContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new WorkTypeConfiguration());
            modelBuilder.Configurations.Add(new OrderMaterialConfiguration());
            modelBuilder.Configurations.Add(new OrderWorkTypeConfiguration());
            modelBuilder.Configurations.Add(new OrderWorkerCostConfiguration());
            modelBuilder.Configurations.Add(new EvaluationConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());

        }
        public IDbSet<UserDb> Users { get; set; }
        public IDbSet<RoleDb> Roles { get; set; }
        public IDbSet<OrderDb> Orders { get; set; }
        public IDbSet<MaterialDb> Materials { get; set; }
        public IDbSet<WorkTypeDb> WorkTypes { get; set; }
        public IDbSet<OrderMaterialDb> OrderMaterials { get; set; }
        public IDbSet<OrderWorkTypeDb> OrderWorkTypes { get; set; }
        public IDbSet<OrderWorkerCostDb> OrderWorkerCosts { get; set; }
        public IDbSet<EvaluationDb> Evaluations { get; set; }
        public IDbSet<DocumentDb> Documents { get; set; }
   
    }
}
