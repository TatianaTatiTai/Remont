using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LAMS.WebApi.Extensions;
using Microsoft.Owin.Security.OAuth;

namespace LAMS.WebApi
{
    public partial class Startup
    {
        private void ConfigureApi(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.ConfigureSwagger();
            configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            configuration.SuppressDefaultHostAuthentication();
            configuration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            app.ConfigureWebApi(configuration);
        }
    }
}