﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows;

namespace html
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
