using System;
using System.Web.UI.WebControls;
using MobileVoting.Web.WebForms.Models;
using WebFormsMvp;

namespace MobileVoting.Web.WebForms.WebFormsMvp.Views.QuestionList
{
    public interface IQuestionListView : IView<QuestionListModel>
    {
        event EventHandler<EventArgs> LoadQuestions;
        event EventHandler<CommandEventArgs> ToggleActivation;

        //void BindQuestionGridViews();
    }
}