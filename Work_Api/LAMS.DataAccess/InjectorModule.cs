using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Common.Repositories.Users;
using LAMS.DataAccess.Common.Repositories.Work;
using LAMS.DataAccess.Common.Repositories.Worker;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories.Admin;
using LAMS.DataAccess.Repositories.Users;
using LAMS.DataAccess.Repositories.Work;
using LAMS.DataAccess.Repositories.Worker;
using Ninject.Modules;

namespace LAMS.DataAccess
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            Bind<DocContext>().ToSelf().InTransientScope();

            BindRepositories();
        }

        private void BindRepositories() { 

            Bind<IUserRepository>().To<UserRepository>();          
            Bind<IAdminRepository>().To<AdminRepository>();
            Bind<IWorkRepository>().To<WorkRepository>();         
            Bind<IWorkerRepository>().To<WorkerRepository>();         
        }
    }
}
