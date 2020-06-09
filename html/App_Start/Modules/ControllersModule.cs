using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using html.ConfigManagement;
using DAL.Models;
using DAL;
using DAL.Interfaces;
using BLL.Services;
using BLL.Interfaces;
using html.Service;
using html.Interfaces;
using BLL.FileSystemStorage;

namespace html.App_Start.Modules
{
    public class ControllersModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //AccountController
            var connectionString = ConfigurationManagement.DBConnectionString();
            builder.Register(ctx => new SQLContext(connectionString)).AsSelf();


            builder.RegisterType<UsersRepository>()
                .As<IRepository>();
            builder.RegisterType<UserService>()
                .As<IUsersService>();

            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();

            //HomeController
            builder.RegisterType<ImageServices>()
                .As<IImagesService>();

            builder.RegisterType<HashService>()
                .As<IHashService>();

            builder.RegisterType<ConfigurationManagement>()
                .AsSelf();

            builder.RegisterType<MediaProvider>()
                .As<IMediaProvider>();

            builder.RegisterType<MediaRepository>()
                .As<IMediaRepository>();

           /* builder.RegisterType<PublisherMQ>()
                .As<IPublisherMQ>();

            builder.RegisterType<NamingService>()
                .As<INamingService>();*/


        }
    }
}