using System;
using System.Web.Http;

namespace Uniplac.Sindicontrata.WebApi
{
    public static class TracingConfig
    {
        public static void Configure()
        {

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}