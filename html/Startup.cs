using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(html.Startup))]

namespace html
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
          /*  app.Run(context =>
            {
                if (context.Request.Path.Value == "/test")
                {
                context.Response.StatusCode = 404;
                return Task.Delay(0); 
                }
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("TEST");
            });*/

        }
    }
}
