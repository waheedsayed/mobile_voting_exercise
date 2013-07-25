using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MobileVoting.Core;

namespace MobileVoting.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public const string PreviousVotesKey = "PREVIOUS_VOTES";

        public static readonly string Title = ConfigurationManager.AppSettings["admin.title"];

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(GetContainer()));
        }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            // register domain types
            builder.RegisterModule(new CoreInjectionModule());
            // register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // build container
            return builder.Build();
        }
    }
}