using System.Web.Mvc;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Admin.Models;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    public class ResultController : Controller
    {
        private readonly IVotingService _votingService;

        public ResultController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public ActionResult Index(int id)
        {
            var result = _votingService.GetResults(id);

            if (result == null)
                return RedirectToAction("Index", "Error");

            var model = new ResultModel {
                Question = result.Question,
                Votes = result.Votes
            };

            return View(model);
        }
    }
}
