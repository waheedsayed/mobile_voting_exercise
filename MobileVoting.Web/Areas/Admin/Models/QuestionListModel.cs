using System.Collections.Generic;
using MobileVoting.Core.Common;

namespace MobileVoting.Web.Areas.Admin.Models
{
    public class QuestionListModel
    {
        public IList<Item<int, string>> ActiveQuestions { get; set; }
        public IList<Item<int, string>> InactiveQuestions { get; set; }
    }
}