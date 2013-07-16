namespace MobileVoting.Core.Models
{
    public class VoteOptionWeight
    {
        public int OptionId { get; set; }
        public int Weight { get; set; }

        public virtual VoteOption VoteOption { get; set; }
    }
}
