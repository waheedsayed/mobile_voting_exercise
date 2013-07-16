using System.Web.Mvc;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Admin.Models;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IVotingService _votingService;

        public QuestionController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                int questionId = _votingService.CreateQuestion(model.Title, model.Text, model.IsActive, (TypeOfQuestion)model.TypeId, model.Options);
                if (questionId <= 0)
                    ModelState.AddModelError("", "Could not create question");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
