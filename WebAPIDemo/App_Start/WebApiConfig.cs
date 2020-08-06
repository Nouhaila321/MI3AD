using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Web.Http;

namespace WebAPIDemo
{
    /*public class CustomJsonFormatter : JsonMediaTypeFormatter { 
           
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }*/


    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            // configure web API to use only bearer token authentication 
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticatioFilter(OAuthDefaults.AuthenticationType));


            // Itinéraires de l'API Web ( Web API routes)
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            //Remove XML Formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Have JSON FROM WEB BROWSER
            //config.Formatters.Add(new CustomJsonFormatter());

            //Stricture of JSON Formatter
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            


        }
    }
}
