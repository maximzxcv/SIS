using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Sis.Interview;
using Sis.Interview.Api.Models.ScrumCeremony;
using Sis.Interview.Dal.Framework;
using Sis.Interview.Dal.Services;
using Sis.Interview.Api;
using Sis.Interview.Api.Framework;
using Sis.Interview.Models.ScrumCeremony;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Sis.Interview.Api
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static IKernel _kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        public static IKernel GetKernel()
        {
            return _kernel;
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

                RegisterServices(kernel); 

                _kernel = kernel;
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InSingletonScope();
            kernel.Bind<BaseService<Retrospective>>().To<RetrospectiveService>();
            kernel.Bind<ILog>().To<NLogger>().WithConstructorArgument("currentClassName", x => x.Request.ParentContext?.Request.Service.FullName);
            kernel.Bind<UnhandledExceptionFilterAttribute>().ToSelf();
            kernel.Bind<LoggingHandler>().ToSelf();
        }
    }
}
