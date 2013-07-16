using System;
using System.Collections.Generic;

namespace MobileVoting.Core.Models
{
    public class Vote
    {
        public Vote()
        {
            VoteOptions = new List<VoteOption>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<VoteOption> VoteOptions { get; set; }
    }
}
