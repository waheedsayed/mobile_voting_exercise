using System.Collections.Generic;

namespace MobileVoting.Web.WebForms.SupervisingControllerPattern.Models
{
    public class QuestionListModel
    {
        public IList<QuestionModel> ActiveQuestions { get; set; }
        public IList<QuestionModel> InactiveQuestions { get; set; }
    }

    public class QuestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}