using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(LAMS.WebApi.Startup))]
namespace LAMS.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            ConfigureMvc();
            ConfigureCors(app);
            ConfigureApi(app);
        }
    }
}