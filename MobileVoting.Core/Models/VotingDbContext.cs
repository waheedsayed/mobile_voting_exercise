using System.Data.Entity;
using MobileVoting.Core.Models.Mapping;

namespace MobileVoting.Core.Models
{
    public class VotingDbContext : DbContext
    {
        static VotingDbContext()
        {
            Database.SetInitializer<VotingDbContext>(null);
        }

        public VotingDbContext()
            : base("Name=VotingDbContext")
        {
        }

        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<VoteOption> VoteOptions { get; set; }
        public DbSet<VoteOptionWeight> VoteOptionWeights { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionOptionMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionTypeMap());
            modelBuilder.Configurations.Add(new VoteOptionMap());
            modelBuilder.Configurations.Add(new VoteOptionWeightMap());
            modelBuilder.Configurations.Add(new VoteMap());
        }
    }
}
