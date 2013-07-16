using System.Web.Mvc;

namespace MobileVoting.Web.Areas.Voter.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}
