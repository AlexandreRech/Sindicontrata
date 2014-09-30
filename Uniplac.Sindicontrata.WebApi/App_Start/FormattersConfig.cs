using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using XNewtonsoft = Newtonsoft.Json.Serialization;

namespace Uniplac.Sindicontrata.WebApi
{
    public class FormattersConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

            jsonFormatter.SerializerSettings.ContractResolver = new XNewtonsoft.CamelCasePropertyNamesContractResolver();
        }
    }
}