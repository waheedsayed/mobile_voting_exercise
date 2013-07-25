using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using MobileVoting.Core.Domain;
using MobileVoting.Web.WebForms.SupervisingControllerPattern.Models;
using MobileVoting.Web.WebForms.SupervisingControllerPattern.Presenters;

namespace MobileVoting.Web.WebForms.SupervisingControllerPattern.Views.QuestionList
{
    public partial class QuestionList : Page, IQuestionListView
    {
        private readonly QuestionListPresenter _presenter;

        public QuestionList()
        {
            var container = MvcApplication.GetContainer();
            var votingService = container.Resolve<IVotingService>();
            _presenter = new QuestionListPresenter(this, votingService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                _presenter.Init();
        }

        public QuestionListModel Model { get; set; }

        public void BindQuestionGridViews()
        {
            ActiveQuestionsGrid.DataSource = Model.ActiveQuestions;
            ActiveQuestionsGrid.DataBind();

            InactiveQuestionsGrid.DataSource = Model.InactiveQuestions;
            InactiveQuestionsGrid.DataBind();
        }

        protected void BtnToggleActivation_Command(object sender, CommandEventArgs e)
        {
            int questionId = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Deactivate":
                    _presenter.Deactivate(questionId);
                    break;
                case "Activate":
                    _presenter.Activate(questionId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}