using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Web;
using MobileVoting.Core;
using MobileVoting.Web.WebForms.SupervisingController.Presenters;
using WebFormsMvp.Autofac;
using WebFormsMvp.Binder;

namespace MobileVoting.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication, IContainerProviderAccessor
    {
        private static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider { get { return _containerProvider; } }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var container = BootstrapAutofac();

            // ASP.NET MVC IoC wiring
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // ASP.NET Web Forms (Supervising Controller) IoC wiring
            _containerProvider = new ContainerProvider(container);

            // ASP.NET Web Forms MVP IoC wiring
            PresenterBinder.Factory = new AutofacPresenterFactory(container);
        }

        private static IContainer BootstrapAutofac()
        {
            var builder = new ContainerBuilder();
            // register Domain Services
            builder.RegisterModule(new CoreInjectionModule());
            // register MVC Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // register Presenters for Supervising Controller
            builder.RegisterType<QuestionListPresenter>().As<IQuestionListPresenter>();
            // build Autofac container
            return builder.Build();
        }
    }
}