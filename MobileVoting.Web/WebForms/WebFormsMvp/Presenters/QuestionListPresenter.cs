using System;
using System.Web.UI.WebControls;
using MobileVoting.Core.Domain;
using MobileVoting.Web.WebForms.Models;
using MobileVoting.Web.WebForms.WebFormsMvp.Views.QuestionList;
using WebFormsMvp;

namespace MobileVoting.Web.WebForms.WebFormsMvp.Presenters
{
    public class QuestionListPresenter : Presenter<IQuestionListView>
    {
        private readonly IVotingService _votingService;

        public QuestionListPresenter(IQuestionListView view, IVotingService votingService)
            : base(view)
        {
            _votingService = votingService;
            // wire view events
            View.LoadQuestions += LoadQuestions;
            View.ToggleActivation += ToggleActivation;
        }

        public void LoadQuestions(object sender, EventArgs e)
        {
            View.Model = LoadModel();
        }

        public void ToggleActivation(object sender, CommandEventArgs e)
        {
            int questionId = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Deactivate":
                    Deactivate(questionId);
                    break;
                case "Activate":
                    Activate(questionId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Deactivate(int questionId)
        {
            _votingService.DeactivateQuestion(questionId);
            View.Model = LoadModel();
        }

        private void Activate(int questionId)
        {
            _votingService.ActivateQuestion(questionId);
            View.Model = LoadModel();
        }

        private QuestionListModel LoadModel()
        {
            return new QuestionListModel {
                ActiveQuestions = _votingService.GetActiveQuestions(),
                InactiveQuestions = _votingService.GetInactiveQuestions()
            };
        }
    }
}