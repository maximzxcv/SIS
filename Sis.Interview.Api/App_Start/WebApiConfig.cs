using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Ninject;
using Sis.Interview.Api.Framework;

namespace Sis.Interview.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = NinjectWebCommon.GetKernel();

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{name}",
                defaults: new {name = RouteParameter.Optional}
            );

            ConfigureFormatters(config); 

            config.Filters.Add(kernel.Get<UnhandledExceptionFilterAttribute>());
            config.MessageHandlers.Add(kernel.Get<LoggingHandler>());
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();

            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.Add(jsonFormatter);

            var xmlFormatter = new XmlMediaTypeFormatter();
            xmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            config.Formatters.Add(xmlFormatter); 
        }
    }
}
