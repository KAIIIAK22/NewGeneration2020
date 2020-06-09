using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using System.Web.Http;
using Autofac.Integration.Mvc;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using html.App_Start.Modules;

namespace html.App_Start
{
    public class DIConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
           
            builder.RegisterControllers(typeof(Global).Assembly);//Global - Global.asax

            builder.RegisterModule<ControllersModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}