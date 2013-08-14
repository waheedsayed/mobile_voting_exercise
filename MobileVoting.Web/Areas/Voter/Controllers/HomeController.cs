using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Voter.Models;

namespace MobileVoting.Web.Areas.Voter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVotingService _votingService;

        public HomeController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public ActionResult Index()
        {
            var previousVotes = Session[Constants.PreviousVotesKey] as List<int> ?? new List<int>();
            var activeQuestions = _votingService.GetActiveQuestions();

            if (activeQuestions == null)
                return RedirectToAction("Index", "Error");

            var model = new QuestionListModel();

            if (activeQuestions.Count > 0 && previousVotes.Count > 0)
            {
                var filteredQuestions = activeQuestions.Where(v => !previousVotes.Contains(v.Id)).ToList();
                model.Questions = filteredQuestions;
                model.NoMoreVotes = filteredQuestions.Count == 0;
            }
            else
            {
                model.Questions = activeQuestions;
                model.NoMoreVotes = false;
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Mobile Voting application.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "http://blog.thinkinuous.com/";
            return View();
        }
    }
}
