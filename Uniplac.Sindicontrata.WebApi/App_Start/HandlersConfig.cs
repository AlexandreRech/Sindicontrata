using Uniplac.Sindicontrata.WebApi.Handlers;
using System.Web.Http;

namespace Uniplac.Sindicontrata.WebApi
{
    public static class HandlersConfig
    {
        public static void RegisterGlobalHandlers(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new LanguageMessageHandler());
        }
    }
}