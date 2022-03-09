using AutoMapper;
using FluentValidation;
using LAMS.Logic.Common.Services.Admin;
using LAMS.Logic.Common.Services.Users;
using LAMS.Logic.Common.Services.Work;
using LAMS.Logic.Common.Services.Worker;
using LAMS.Logic.Mappings.Admin;
using LAMS.Logic.Mappings.Users;
using LAMS.Logic.Mappings.Work;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Services.Users;
using LAMS.Logic.Services.Work;
using LAMS.Logic.Services.Worker;
using Ninject.Modules;
using System.Reflection;

namespace LAMS.Logic
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            BindValidators();
            BindMappers();

            BindLogsServices();
        }

        private void BindValidators()
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => Kernel.Bind(result.InterfaceType).To(result.ValidatorType).InTransientScope());
        }

        private void BindMappers()
        {

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<UserService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<RegistrationService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OrderProfile>();
                    cfg.AddProfile<MaterialProfile>();
                    cfg.AddProfile<WorkTypeProfile>();
                    cfg.AddProfile<OrderMaterialProfile>();
                    cfg.AddProfile<OrderWorkTypeProfile>();
                    cfg.AddProfile<OrderWorkerCostProfile>();
                    cfg.AddProfile<DocumentProfile>();
                })))
                .WhenInjectedExactlyInto<WorkService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OrderProfile>();
                    cfg.AddProfile<MaterialProfile>();
                    cfg.AddProfile<WorkTypeProfile>();
                })))
                .WhenInjectedExactlyInto<AdminService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OrderProfile>();
                    cfg.AddProfile<MaterialProfile>();
                    cfg.AddProfile<WorkTypeProfile>();
                    cfg.AddProfile<OrderMaterialProfile>();
                    cfg.AddProfile<OrderWorkTypeProfile>();
                    cfg.AddProfile<OrderWorkerCostProfile>();
                    cfg.AddProfile<EvaluationProfile>();
                    cfg.AddProfile<DocumentProfile>();
                })))
                .WhenInjectedExactlyInto<WorkerService>();



        }


        private void BindLogsServices()
        {
            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IUserService>().To<UserService>();
            Bind<IAdminService>().To<AdminService>();
            Bind<IWorkService>().To<WorkService>();
            Bind<IWorkerService>().To<WorkerService>();
        }
    }
}
