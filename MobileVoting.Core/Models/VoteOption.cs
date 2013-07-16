namespace MobileVoting.Core.Models
{
    public class VoteOption
    {
        public int Id { get; set; }
        public int VoteId { get; set; }
        public int OptionId { get; set; }

        public virtual Vote Vote { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
        public virtual VoteOptionWeight VoteOptionWeight { get; set; }
    }
}
