using System.Linq;
using MobileVoting.Core.Domain;
using MobileVoting.Core.Web;
using MobileVoting.Web.WebForms.SupervisingControllerPattern.Models;
using MobileVoting.Web.WebForms.SupervisingControllerPattern.Views.QuestionList;

namespace MobileVoting.Web.WebForms.SupervisingControllerPattern.Presenters
{
    public class QuestionListPresenter : IPresenter<IQuestionListView, QuestionListModel>
    {
        private readonly IVotingService _votingService;
        private readonly IQuestionListView _view;

        public QuestionListPresenter(IQuestionListView view, IVotingService votingService)
        {
            _view = view;
            _votingService = votingService;
        }

        public void Init()
        {
            _view.Model = LoadModel();
            _view.BindQuestionGridViews();
        }

        public void Deactivate(int questionId)
        {
            _votingService.DeactivateQuestion(questionId);
            _view.Model = LoadModel();
            _view.BindQuestionGridViews();
        }

        public void Activate(int questionId)
        {
            _votingService.ActivateQuestion(questionId);
            _view.Model = LoadModel();
            _view.BindQuestionGridViews();
        }

        private QuestionListModel LoadModel()
        {
            return new QuestionListModel {
                ActiveQuestions = _votingService.GetActiveQuestions().Select(q => new QuestionModel { Id = q.Key, Title = q.Value }).ToList(),
                InactiveQuestions = _votingService.GetInactiveQuestions().Select(q => new QuestionModel { Id = q.Key, Title = q.Value }).ToList()
            };
        }
    }
}