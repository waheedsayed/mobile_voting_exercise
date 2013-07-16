using System.Collections.Generic;

namespace MobileVoting.Core.Models
{
    public class QuestionType
    {
        public QuestionType()
        {
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
