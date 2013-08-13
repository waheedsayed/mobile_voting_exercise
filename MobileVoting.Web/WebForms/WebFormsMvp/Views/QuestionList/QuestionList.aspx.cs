using System;
using System.Web.UI.WebControls;
using MobileVoting.Web.WebForms.Models;
using MobileVoting.Web.WebForms.WebFormsMvp.Presenters;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace MobileVoting.Web.WebForms.WebFormsMvp.Views.QuestionList
{
    [PresenterBinding(typeof(QuestionListPresenter))]
    public partial class QuestionList : MvpPage<QuestionListModel>, IQuestionListView
    {
        public event EventHandler<EventArgs> LoadQuestions;
        public event EventHandler<CommandEventArgs> ToggleActivation;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadQuestions(this, null);
            BindQuestionGridViews();
        }

        protected void BtnToggleActivation_Command(object sender, CommandEventArgs e)
        {
            ToggleActivation(this, e);
            BindQuestionGridViews();
        }

        private void BindQuestionGridViews()
        {
            ActiveQuestionsGrid.DataSource = Model.ActiveQuestions;
            ActiveQuestionsGrid.DataBind();

            InactiveQuestionsGrid.DataSource = Model.InactiveQuestions;
            InactiveQuestionsGrid.DataBind();
        }
    }
}