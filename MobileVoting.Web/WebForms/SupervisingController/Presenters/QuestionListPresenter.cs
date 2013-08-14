using MobileVoting.Core.Domain;
using MobileVoting.Core.Web;
using MobileVoting.Web.WebForms.Models;
using MobileVoting.Web.WebForms.SupervisingController.Views.QuestionList;

namespace MobileVoting.Web.WebForms.SupervisingController.Presenters
{
    public interface IQuestionListPresenter : IPresenter<IQuestionListView, QuestionListModel>
    {
        void LoadQuestions();
        void Deactivate(int questionId);
        void Activate(int questionId);
    }

    public class QuestionListPresenter : IQuestionListPresenter
    {
        private readonly IVotingService _votingService;

        private IQuestionListView _view;

        public QuestionListPresenter(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public void AttachToView(IView<QuestionListModel> view)
        {
            _view = (IQuestionListView)view;
        }

        public void LoadQuestions()
        {
            _view.Model = LoadModel();
        }

        public void Deactivate(int questionId)
        {
            _votingService.DeactivateQuestion(questionId);
            _view.Model = LoadModel();
        }

        public void Activate(int questionId)
        {
            _votingService.ActivateQuestion(questionId);
            _view.Model = LoadModel();
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