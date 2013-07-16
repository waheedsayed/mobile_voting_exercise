using System;
using System.Collections.Generic;

namespace MobileVoting.Core.Models
{
    public class Question
    {
        public Question()
        {
            Options = new List<QuestionOption>();
            Votes = new List<Vote>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public int TypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<QuestionOption> Options { get; set; }
        public virtual QuestionType Type { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
