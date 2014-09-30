using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using System.Web.Http.Validation;
using FluentValidation;
using FluentValidation.WebApi;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Extensions.Logging;
using Ninject.Web.Common;
using Uniplac.Sindicontrata.WebApi.Controllers;
using Uniplac.Sindicontrata.WebApi.Factories;
using Uniplac.Sindicontrata.WebApi.Interceptors;
using Uniplac.Sindicontrata.WebApi.Loggers;
using Uniplac.Sindicontrata.WebApi.Providers;
using WebApiContrib.IoC.Ninject;
using System.Collections.ObjectModel;
using System.Web.Compilation;
using System.IO;
using Uniplac.Sindicontrata.Aplicacao.FornecedorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts;
using Uniplac.Sindicontrata.Dominio.FornecedorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories;

namespace Uniplac.Sindicontrata.WebApi.DependencyResolution
{
    public static class IoC
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterValidators(kernel);

            RegisterDependencyResolver(kernel);

            RegisterFilters(kernel);

            RegisterServices(kernel);

            RegisterLoggers(kernel);

            return kernel;
        }

        private static void RegisterDependencyResolver(StandardKernel kernel)
        {
            //Suport WebAPI Controllers Injection
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }

        private static void RegisterFilters(IKernel kernel)
        {
            //Suuport injection in WebAPI filters (Repo in filter ServicePortalAuthorizeAttribute)
            GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider), new NinjectWebApiFilterProvider(kernel));
        }

        private static void RegisterLoggers(IKernel kernel)
        {
            var loggerFactory = kernel.Get<ILoggerFactory>();

            kernel.Bind<ITraceWriter>()
                .To<WebApiTracerLogger>()
                .InTransientScope()
                .WithConstructorArgument("loggerFactory", loggerFactory);
        }

        private static void RegisterValidators(IKernel kernel)
        {
            kernel.Bind<ModelValidatorProvider>().To<FluentValidationModelValidatorProvider>();

            kernel.Bind<IValidatorFactory>().To<NinjectValidatorFactory>().InSingletonScope();

            Assembly assembly = AssemblyLocator.GetAssemblyByName("Uniplac.Sindicontrata.CommandQueries");

            //Register all validators in project
            AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(match => kernel.Bind(match.InterfaceType)
                    .To(match.ValidatorType));

            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration,
               x => x.ValidatorFactory = kernel.Get<IValidatorFactory>());
        }

        private static void RegisterServices(IKernel kernel)
        {          
            kernel.Bind<IDatabaseFactory>()
               .To<DatabaseFactory>()
               .InRequestScope();

            kernel.Bind<IUnitOfWork>()
               .To<UnitOfWork>()
               .InRequestScope();

            kernel.Bind<SindicontrataContext>()
                .ToSelf()
                .InRequestScope();               

            kernel.Bind<IFornecedorService>()
               .To<FornecedorService>()
               .Intercept()
               .With<StopWatchNinjectInterceptor>();

            kernel.Bind<IFornecedorRepository>()
               .To<FornecedorRepository>();
               
        }
    }

    public static class AssemblyLocator
    {
        private static readonly ReadOnlyCollection<Assembly> AllAssemblies;
        private static readonly ReadOnlyCollection<Assembly> BinAssemblies;

        static AssemblyLocator()
        {
            AllAssemblies = new ReadOnlyCollection<Assembly>(
                BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList());

            IList<Assembly> binAssemblies = new List<Assembly>();

            string binFolder = HttpRuntime.AppDomainAppPath + "bin\\";
            IList<string> dllFiles = Directory.GetFiles(binFolder, "*.dll",
                SearchOption.TopDirectoryOnly).ToList();

            foreach (string dllFile in dllFiles)
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllFile);

                Assembly locatedAssembly = AllAssemblies.FirstOrDefault(a =>
                    AssemblyName.ReferenceMatchesDefinition(
                        a.GetName(), assemblyName));

                if (locatedAssembly != null)
                {
                    binAssemblies.Add(locatedAssembly);
                }
            }

            BinAssemblies = new ReadOnlyCollection<Assembly>(binAssemblies);
        }

        public static Assembly GetAssemblyByName(string name)
        {
            return AllAssemblies.First(x => x.FullName.Contains(name));
        }

        public static ReadOnlyCollection<Assembly> GetAssemblies()
        {
            return AllAssemblies;
        }

        public static ReadOnlyCollection<Assembly> GetBinFolderAssemblies()
        {
            return BinAssemblies;
        }
    }
}