﻿using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using html.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(html.Startup))]

namespace html
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // AuthConfig(app);
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


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(60)
            });


            DIConfig.Configure(new HttpConfiguration());
        }

       /* private static void AuthConfig(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
            });
        }*/
    }
}
