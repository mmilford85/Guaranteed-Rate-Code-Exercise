namespace GRCE.Web
{
    using System;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

#if DEBUG
            //For testing GET commands from the browser (Forces json return type)
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true, "application/json"));
#endif
            UnityConfig.RegisterComponents();
        }

        protected void Application_End()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}
