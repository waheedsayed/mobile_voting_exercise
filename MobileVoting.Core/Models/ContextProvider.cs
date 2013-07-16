namespace MobileVoting.Core.Models
{
    public interface IContextProvider
    {
        VotingDbContext GetMobileVotingDbContext();
    }

    public class ContextProvider : IContextProvider
    {
        public VotingDbContext GetMobileVotingDbContext()
        {
            return new VotingDbContext();
        }
    }
}
