using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Web;

namespace Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Código que é executado no encerramento do aplicativo

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Código que é executado quando ocorre um erro não tratado

        }
    }
}
