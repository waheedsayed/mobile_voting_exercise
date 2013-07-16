using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Voter.Models;

namespace MobileVoting.Web.Areas.Voter.Controllers
{
    public class VoteController : Controller
    {
        private readonly IVotingService _votingService;

        public VoteController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public ActionResult New(int id)
        {
            var question = _votingService.GetQuestion(id);

            if (question == null)
                throw new Exception("Failed to load question details");

            var model = new ChoiceVoteModel {
                Question = question,
                Type = (TypeOfQuestion)question.TypeId
            };

            switch ((TypeOfQuestion)model.Question.TypeId)
            {
                case TypeOfQuestion.SingleChoice:
                case TypeOfQuestion.MultipleChoice:
                    return View("ChoiceVote", model);
                case TypeOfQuestion.Ranking:
                case TypeOfQuestion.Rating:
                    return Content("Under construction type.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SaveChoiceVoteModel model)
        {
            if (!_votingService.SaveVote(model.QuestionId, model.VoteOptions))
                return RedirectToAction("Index", "Error");

            var previousVotes = Session[MvcApplication.PreviousVotesKey] as List<int> ?? new List<int>();
            previousVotes.Add(model.QuestionId);
            Session[MvcApplication.PreviousVotesKey] = previousVotes;
            return RedirectToAction("Index", "Home");
        }
    }
}
