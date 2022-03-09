using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LAMS.WebApi.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(LAMS.WebApi.NinjectWebCommon), "Stop")]

namespace LAMS.WebApi
{
    /// <summary>
    /// Ninject Bootstrapper wrapper
    /// </summary>
    public static class NinjectWebCommon 
    {
        private static bool _isStarted = false;

        /// <inheritdoc cref="Bootstrapper"/>
        public static Bootstrapper Bootstrapper { get; } = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            if (_isStarted)
                return;

            _isStarted = true;

            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {            
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Load(new DataAccess.InjectorModule(), new Logic.InjectorModule());

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }   
    }
}