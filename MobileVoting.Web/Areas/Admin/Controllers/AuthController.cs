using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using MobileVoting.Web.Areas.Admin.Models;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private static readonly string _adminPassword = ConfigurationManager.AppSettings["admin.password"];

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(_adminPassword) && _adminPassword == model.Password)
                {
                    FormsAuthentication.SetAuthCookie("admin", true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid administrator credentials");
            }

            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}
