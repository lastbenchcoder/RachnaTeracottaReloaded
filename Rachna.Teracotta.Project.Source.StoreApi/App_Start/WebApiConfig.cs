using Rachna.Teracotta.Project.Source.DAO.bal;
using Rachna.Teracotta.Project.Source.DAO.dal;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Rachna.Teracotta.Project.Source.StoreApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            UnityContainer container = new UnityContainer();

            container.RegisterType<bStores>();
            container.RegisterType<dStores>();
            container.RegisterType<iStore, dStores>();

            container.RegisterType<bInvitations>();
            container.RegisterType<dInvitations>();
            container.RegisterType<iInvitations, dInvitations>();

            container.RegisterType<bAdministrator>();
            container.RegisterType<dAdministrator>();
            container.RegisterType<iAdministrator, dAdministrator>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
