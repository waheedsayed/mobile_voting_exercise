using System.Collections.Generic;

namespace MobileVoting.Core.Models
{
    public class QuestionOption
    {
        public QuestionOption()
        {
            VoteOptions = new List<VoteOption>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<VoteOption> VoteOptions { get; set; }
    }
}
