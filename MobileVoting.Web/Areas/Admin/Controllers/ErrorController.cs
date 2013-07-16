using System.Web.Mvc;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult GeneralError()
        {
            //TODO: Need logging here
            return View("Error");
        }
    }
}
