using MobileVoting.Core.Domain;
using MobileVoting.Core.Models;

namespace MobileVoting.Web.Areas.Voter.Models
{
    public class ChoiceVoteModel
    {
        public Question Question { get; set; }
        public TypeOfQuestion Type { get; set; }
    }
}