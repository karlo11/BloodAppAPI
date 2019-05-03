using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Net.Http.Formatting;

namespace WebAPIForBloodApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*GlobalConfiguration.Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft
                                                .Json
                                                .ReferenceLoopHandling
                                                .Ignore;*/
            /* GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                 new JsonSerializerSettings
                 {
                     DateFormatHandling = DateFormatHandling.IsoDateFormat,
                     DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                     Culture = CultureInfo.GetCultureInfo("hr-HR")
                 };*/

            JsonMediaTypeFormatter jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Culture = CultureInfo.GetCultureInfo("hr-HR")
            };
            jSettings.Converters.Add(new MyDateTimeConvertor());
            jsonFormatter.SerializerSettings = jSettings;

            GlobalConfiguration.Configuration
                .Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }

    public class MyDateTimeConvertor : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy HH:mm"));
        }
    }
}
