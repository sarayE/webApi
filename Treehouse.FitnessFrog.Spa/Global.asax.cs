using System;
using System.Web;
using System.Web.Http;

namespace Treehouse.FitnessFrog.Spa
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start() //This method call every time  that the web app is started
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
