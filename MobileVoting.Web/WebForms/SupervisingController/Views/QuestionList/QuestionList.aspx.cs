using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileVoting.Web.WebForms.Models;
using MobileVoting.Web.WebForms.SupervisingController.Presenters;

namespace MobileVoting.Web.WebForms.SupervisingController.Views.QuestionList
{
    public partial class QuestionList : Page, IQuestionListView
    {
        public IQuestionListPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.AttachToView(this);

            if (IsPostBack) return;

            Presenter.LoadQuestions();
            BindQuestionGridViews();
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
                    Presenter.Deactivate(questionId);
                    break;
                case "Activate":
                    Presenter.Activate(questionId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            BindQuestionGridViews();
        }
    }
}