using System;
using System.Collections.Generic;
using System.Linq;
using MobileVoting.Core.Common;
using MobileVoting.Core.Domain;
using MobileVoting.Core.Models;
using MobileVoting.Core.Projections;

namespace MobileVoting.Core.Repositories
{
    public interface IVotingRepository
    {
        int CreateQuestion(string title, string text, TypeOfQuestion type, bool isActive, params string[] options);
        IList<QuestionDto> GetActiveQuestions();
        IList<QuestionDto> GetInctiveQuestions();
        void ActivateQuestion(int questionId);
        void DeactivateQuestion(int questionId);
        Question GetQuestion(int id);
        void SaveVote(int questionId, params int[] voteOptionIds);
        VoteResult GetVotes(int questionId);
    }

    public class VotingRepository : IVotingRepository
    {
        private readonly IContextProvider _contextProvider;

        public VotingRepository(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public int CreateQuestion(string title, string text, TypeOfQuestion type, bool isActive, params string[] options)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                var newQuestion = new Question {
                    Title = title,
                    Text = text,
                    IsActive = isActive,
                    TypeId = (int)type,
                    Options = options.Select(o => new QuestionOption { Text = o }).ToList(),
                    DateCreated = DateTime.Now
                };
                context.Questions.Add(newQuestion);
                context.SaveChanges();
                return newQuestion.Id;
            }
        }

        public IList<QuestionDto> GetActiveQuestions()
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                return (from q in context.Questions
                        where q.IsActive
                        orderby q.DateCreated descending
                        select new QuestionDto { Id = q.Id, Title = q.Title }).ToList();
            }
        }

        public IList<QuestionDto> GetInctiveQuestions()
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                return (from q in context.Questions
                        where !q.IsActive
                        orderby q.DateCreated descending
                        select new QuestionDto { Id = q.Id, Title = q.Title }).ToList();
            }
        }

        public void ActivateQuestion(int questionId)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                context.Questions.Find(questionId).IsActive = true;
                context.SaveChanges();
            }
        }

        public void DeactivateQuestion(int questionId)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                context.Questions.Find(questionId).IsActive = false;
                context.SaveChanges();
            }
        }

        public Question GetQuestion(int id)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                return (from q in context.Questions.Include("Options")
                        where q.Id == id
                        select q).FirstOrDefault();
            }
        }

        public void SaveVote(int questionId, int[] voteOptionIds)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                var vote = new Vote {
                    QuestionId = questionId,
                    DateCreated = DateTime.Now
                };
                var voteOptions = voteOptionIds.Select(optionId => new VoteOption { OptionId = optionId }).ToArray();
                vote.VoteOptions = voteOptions;
                context.Votes.Add(vote);
                context.VoteOptions.AddRange(voteOptions);
                context.SaveChanges();
            }
        }

        public VoteResult GetVotes(int questionId)
        {
            using (var context = _contextProvider.GetMobileVotingDbContext())
            {
                var query = from q in context.Questions
                            join qo in context.QuestionOptions on q.Id equals qo.QuestionId
                            join v in context.Votes on q.Id equals v.QuestionId
                            join vo in context.VoteOptions on new { VoteId = v.Id, OptionId = qo.Id } equals new { vo.VoteId, vo.OptionId }
                            where q.Id == questionId
                            group q by new { Option = qo.Text }
                                into grp
                                select new Item<string, int> {
                                    Key = grp.Key.Option,
                                    Value = grp.Count()
                                };
                string question = (from q in context.Questions where q.Id == questionId select q.Text).First();
                return new VoteResult { Question = question, Votes = query.ToList() };
            }
        }
    }
}