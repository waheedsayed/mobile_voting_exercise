using Autofac;
using MobileVoting.Core.Common;
using MobileVoting.Core.Domain;
using MobileVoting.Core.Helpers;
using MobileVoting.Core.Models;
using MobileVoting.Core.Repositories;

namespace MobileVoting.Core
{
    public class CoreInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(NLogService<>)).As(typeof(ILogService<>));
            builder.RegisterType<ContextProvider>().As<IContextProvider>();
            builder.RegisterType<VotingRepository>().As<IVotingRepository>();
            builder.RegisterType<VotingService>().As<IVotingService>().PropertiesAutowired();
            builder.RegisterType<VotesGenerator>().As<IVotesGenerator>();
        }
    }
}
