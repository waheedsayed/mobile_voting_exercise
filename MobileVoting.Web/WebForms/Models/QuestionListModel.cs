using System.Collections.Generic;
using MobileVoting.Core.Projections;

namespace MobileVoting.Web.WebForms.Models
{
    public class QuestionListModel
    {
        public IList<QuestionDto> ActiveQuestions { get; set; }
        public IList<QuestionDto> InactiveQuestions { get; set; }
    }
}