using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Uniplac.Sindicontrata.WebApi.DependencyResolution;
using System.Web.Http;

[assembly: OwinStartup(typeof(Uniplac.Sindicontrata.WebApi.Startup))]
namespace Uniplac.Sindicontrata.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            OAuthConfig.ConfigureOAuth(app);

            HandlersConfig.RegisterGlobalHandlers(config);

            RoutesConfig.Register(config);

            FormattersConfig.Configure(config);

            FiltersConfig.RegisterGlobalFilters(config);

            BindersConfig.RegisterGlobalBinders(config);

            TracingConfig.Configure();

            app.UseCors(CorsOptions.AllowAll);

            app.UseNinjectMiddleware(IoC.CreateKernel);

            app.UseNinjectWebApi(config);
        }


    }
}