﻿using System;
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
using Uniplac.Sindicontrata.WebApi.Services;
using WebApiContrib.IoC.Ninject;

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

            //Register all validators in project
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(match => kernel.Bind(match.InterfaceType)
                    .To(match.ValidatorType));

            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration,
               x => x.ValidatorFactory = kernel.Get<IValidatorFactory>());
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuthService>()
                .To<AuthServiceStub>()
                .Intercept()
               .With<StopWatchNinjectInterceptor>();


            kernel.Bind<IEventService>()
               .To<EventServiceStub>()
               .Intercept()
               .With<StopWatchNinjectInterceptor>();

        }
    }
}