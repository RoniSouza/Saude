﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Web
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            // Consulte http://go.microsoft.com/fwlink/?LinkId=252803 para obter detalhes sobre como configurar este ASP.NET
            // aplicativo para suportar registro em log por meio de serviços externos.

            //OpenAuth.AuthenticationClients.AddTwitter(
            //    consumerKey: "sua chave de consumidor no Twitter",
            //    consumerSecret: "seu segredo de consumidor no Twitter");

            //OpenAuth.AuthenticationClients.AddFacebook(
            //    appId: "sua ID do aplicativo no Facebook",
            //    appSecret: "seu segredo do aplicativo no Facebook");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "sua ID de cliente da conta Microsoft",
            //    clientSecret: "seu segredo de cliente da conta Microsoft");

            //OpenAuth.AuthenticationClients.AddGoogle();
        }
    }
}