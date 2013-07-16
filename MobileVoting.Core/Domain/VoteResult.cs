using System.Collections.Generic;
using MobileVoting.Core.Common;

namespace MobileVoting.Core.Domain
{
    public class VoteResult
    {
        public string Question { get; set; }
        public List<Item<string, int>> Votes { get; set; }
    }
}