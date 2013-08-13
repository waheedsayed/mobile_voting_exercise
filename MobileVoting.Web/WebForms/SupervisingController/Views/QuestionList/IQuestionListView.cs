using MobileVoting.Core.Web;
using MobileVoting.Web.WebForms.Models;

namespace MobileVoting.Web.WebForms.SupervisingController.Views.QuestionList
{
    public interface IQuestionListView : IView<QuestionListModel>
    {
        void BindQuestionGridViews();
    }
}