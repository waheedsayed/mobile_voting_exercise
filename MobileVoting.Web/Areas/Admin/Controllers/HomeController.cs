using System.Web.Mvc;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Admin.Models;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVotingService _votingService;

        public HomeController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public ActionResult Index()
        {
            var model = new QuestionListModel {
                ActiveQuestions = _votingService.GetActiveQuestions(),
                InactiveQuestions = _votingService.GetInactiveQuestions()
            };
            return View(model);
        }

        public ActionResult ToggleActivation(ActivationModel model)
        {
            if (model.Activate)
                _votingService.ActivateQuestion(model.QuestionId);
            else
                _votingService.DeactivateQuestion(model.QuestionId);

            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return new ContentResult { Content = "<h2>Not Implemented Yet</h2>" };
        }

        public ActionResult Result(int id)
        {
            return RedirectToAction("Index", "Result", new { id });
        }
    }
}
