using System.Collections.Generic;
using MobileVoting.Core.Common;

namespace MobileVoting.Web.Areas.Voter.Models
{
    public class QuestionListModel
    {
        public bool NoMoreVotes { get; set; }
        public IList<Item<int, string>> Questions { get; set; }
    }
}