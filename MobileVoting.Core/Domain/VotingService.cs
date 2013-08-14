using System;
using System.Collections.Generic;
using MobileVoting.Core.Common;
using MobileVoting.Core.Models;
using MobileVoting.Core.Projections;
using MobileVoting.Core.Repositories;

namespace MobileVoting.Core.Domain
{
    public interface IVotingService
    {
        int CreateQuestion(string title, string text, bool isActive, TypeOfQuestion type, params string[] options);
        IList<QuestionDto> GetActiveQuestions();
        IList<QuestionDto> GetInactiveQuestions();
        bool ActivateQuestion(int questionId);
        bool DeactivateQuestion(int questionId);
        Question GetQuestion(int questionId);
        bool SaveVote(int questionId, int[] voteOptionIds);
        VoteResult GetResults(int questionId);
    }

    public class VotingService : IVotingService
    {
        private readonly ILogService<VotingService> _logService;
        private readonly IVotingRepository _votingRepository;

        public VotingService(ILogService<VotingService> logService, IVotingRepository votingRepository)
        {
            _logService = logService;
            _votingRepository = votingRepository;
        }

        public int CreateQuestion(string title, string text, bool isActive, TypeOfQuestion type, params string[] options)
        {
            try
            {
                int questionId = _votingRepository.CreateQuestion(title, text, type, isActive, options);
                _logService.Logger.Info("Question #{0} has been added", questionId);
                return questionId;
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to create a question. Reason:\r\n{0}", exception.ToString());
                return -1;
            }
        }

        public IList<QuestionDto> GetActiveQuestions()
        {
            try
            {
                return _votingRepository.GetActiveQuestions();
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to retrieve active questions. Reason:\r\n{0}", exception.ToString());
                return null;
            }
        }

        public IList<QuestionDto> GetInactiveQuestions()
        {
            try
            {
                return _votingRepository.GetInctiveQuestions();
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to retrieve inactive questions. Reason:\r\n{0}", exception.ToString());
                return null;
            }
        }

        public bool ActivateQuestion(int questionId)
        {
            try
            {
                _votingRepository.ActivateQuestion(questionId);
                _logService.Logger.Info("Question #{0} has been activated", questionId);
                return true;
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to activate Question #{1}. Reason:\r\n{0}", exception.ToString(), questionId);
                return false;
            }
        }

        public bool DeactivateQuestion(int questionId)
        {
            try
            {
                _votingRepository.DeactivateQuestion(questionId);
                _logService.Logger.Info("Question #{0} has been deactivated", questionId);
                return true;
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to deactivate Question #{1}. Reason:\r\n{0}", exception.ToString(), questionId);
                return false;
            }
        }

        public Question GetQuestion(int questionId)
        {
            try
            {
                return _votingRepository.GetQuestion(questionId);
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to retrieve Question #{1}. Reason:\r\n{0}", exception.ToString(), questionId);
                return null;
            }
        }

        public bool SaveVote(int questionId, int[] voteOptionIds)
        {
            try
            {
                _votingRepository.SaveVote(questionId, voteOptionIds);
                return true;
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to save a vote for question #{1}. Reasons: {0}", exception, questionId);
                return false;
            }
        }

        public VoteResult GetResults(int questionId)
        {
            try
            {
                return _votingRepository.GetVotes(questionId);
            }
            catch (Exception exception)
            {
                _logService.Logger.Error("Failed to retrieve votes for question #{1}. Reasons: {0}", exception, questionId);
                return null;
            }
        }
    }
}
