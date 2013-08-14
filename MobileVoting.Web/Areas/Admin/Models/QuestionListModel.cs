using System.Collections.Generic;
using MobileVoting.Core.Projections;

namespace MobileVoting.Web.Areas.Admin.Models
{
    public class QuestionListModel
    {
        public IList<QuestionDto> ActiveQuestions { get; set; }
        public IList<QuestionDto> InactiveQuestions { get; set; }
    }
}