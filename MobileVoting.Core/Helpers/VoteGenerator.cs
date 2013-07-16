using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileVoting.Core.Domain;

namespace MobileVoting.Core.Helpers
{
    public interface IVotesGenerator
    {
        void GenerateQuestionsAndVotes();
    }

    public class VotesGenerator : IVotesGenerator
    {
        private readonly IVotingService _votingService;
        private readonly Random _randomiser = new Random();

        public VotesGenerator(IVotingService votingService)
        {
            _votingService = votingService;
        }

        public void GenerateQuestionsAndVotes()
        {
            Parallel.For(0, 100, count => {
                int numberOfOptions = _randomiser.Next(2, 7);
                int questionId = GenerateQuestion(TypeOfQuestion.SingleChoice, count,
                                                  numberOfOptions);
                var question = _votingService.GetQuestion(questionId);
                var options = question.Options.Select(o => o.Id).ToArray();
                GenerateVotes(questionId, options);
            });
        }

        private int GenerateQuestion(TypeOfQuestion type, int sequence, int numberOfOptions)
        {
            switch (type)
            {
                case TypeOfQuestion.SingleChoice:
                    string title = "Title " + sequence;
                    string text = "Text" + sequence;
                    var options = new List<string>();
                    for (int i = 0; i < numberOfOptions; i++)
                        options.Add("Option " + i);
                    return _votingService.CreateQuestion(title, text, true, type, options.ToArray());
                default:
                    throw new NotImplementedException();
            }
        }

        private void GenerateVotes(int questionId, int[] optionIds)
        {
            int numberOfVotes = _randomiser.Next(20, 100);

            for (int i = 0; i < numberOfVotes; i++)
            {
                int optionId = PickRandomOption(optionIds);
                bool success = _votingService.SaveVote(questionId, new[] { optionId });
                if (!success) throw new Exception("Failed to vote for Question #" + questionId);
            }
        }

        private int PickRandomOption(int[] optionIds)
        {
            int optionId;

            do
            {
                optionId = _randomiser.Next(optionIds.First(), optionIds.Last());
            } while (!optionIds.Contains(optionId));

            return optionId;
        }
    }
}
