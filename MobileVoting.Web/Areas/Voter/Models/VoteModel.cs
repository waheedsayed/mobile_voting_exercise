namespace MobileVoting.Web.Areas.Voter.Models
{
    public class SaveChoiceVoteModel
    {
        public int QuestionId { get; set; }
        public int[] VoteOptions { get; set; }
    }
}