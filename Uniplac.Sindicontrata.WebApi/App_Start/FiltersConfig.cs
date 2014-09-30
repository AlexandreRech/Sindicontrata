using Uniplac.Sindicontrata.WebApi.Filters;
using System.Web.Http;

namespace Uniplac.Sindicontrata.WebApi
{
    public static class FiltersConfig
    {
        public static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //  config.Filters.Add(new AuthorizeAttribute());

            config.Filters.Add(new ValidateModelFilterAttribute());

            config.Filters.Add(new LoggingFilterAttribute());

        }
    }
}