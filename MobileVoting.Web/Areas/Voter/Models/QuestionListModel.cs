using System.Collections.Generic;
using MobileVoting.Core.Projections;

namespace MobileVoting.Web.Areas.Voter.Models
{
    public class QuestionListModel
    {
        public bool NoMoreVotes { get; set; }
        public IList<QuestionDto> Questions { get; set; }
    }
}