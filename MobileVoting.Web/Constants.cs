using System.Configuration;

namespace MobileVoting.Web
{
    public class Constants
    {
        public const string PreviousVotesKey = "PREVIOUS_VOTES";

        public static readonly string PageTitle = ConfigurationManager.AppSettings["admin.title"];
    }
}