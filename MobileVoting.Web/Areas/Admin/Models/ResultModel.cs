using System.Collections.Generic;
using MobileVoting.Core.Common;

namespace MobileVoting.Web.Areas.Admin.Models
{
    public class ResultModel
    {
        public string Question { get; set; }
        public List<Item<string, int>> Votes { get; set; }
    }
}