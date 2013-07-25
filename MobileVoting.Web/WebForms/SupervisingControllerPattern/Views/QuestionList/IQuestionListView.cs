using MobileVoting.Core.Web;
using MobileVoting.Web.WebForms.SupervisingControllerPattern.Models;

namespace MobileVoting.Web.WebForms.SupervisingControllerPattern.Views.QuestionList
{
    public interface IQuestionListView : IView<QuestionListModel>
    {
        void BindQuestionGridViews();
    }
}