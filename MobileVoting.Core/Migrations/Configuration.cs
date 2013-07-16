using System.Data.Entity.Migrations;
using MobileVoting.Core.Models;

namespace MobileVoting.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VotingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VotingDbContext context)
        {
            context.QuestionTypes.AddOrUpdate(
                new QuestionType { Id = 1, TypeName = "Single choice" },
                new QuestionType { Id = 2, TypeName = "Multiple choice" },
                new QuestionType { Id = 3, TypeName = "Ranking" },
                new QuestionType { Id = 4, TypeName = "Rating" });
        }
    }
}
