using System.Web.Mvc;
using MobileVoting.Core.Helpers;

namespace MobileVoting.Web.Areas.Admin.Controllers
{
    public class GeneratorController : Controller
    {
        private readonly IVotesGenerator _votesGenerator;

        public GeneratorController(IVotesGenerator votesGenerator)
        {
            _votesGenerator = votesGenerator;
        }

        public ActionResult Index()
        {
            _votesGenerator.GenerateQuestionsAndVotes();
            return RedirectToAction("Index", "Home");
        }
    }
}
