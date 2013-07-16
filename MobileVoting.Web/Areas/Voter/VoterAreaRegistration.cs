using System.Web.Mvc;

namespace MobileVoting.Web.Areas.Voter
{
    public class VoterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Voter"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Voter_default",
                "Voter/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
