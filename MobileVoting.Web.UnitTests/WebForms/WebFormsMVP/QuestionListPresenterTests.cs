using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MobileVoting.Core.Domain;
using MobileVoting.Core.Projections;
using MobileVoting.Web.UnitTests.Helpers;
using MobileVoting.Web.WebForms.Models;
using MobileVoting.Web.WebForms.WebFormsMvp.Presenters;
using MobileVoting.Web.WebForms.WebFormsMvp.Views.QuestionList;
using NSubstitute;
using NUnit.Framework;

namespace MobileVoting.Web.UnitTests.WebForms.WebFormsMVP
{
    [TestFixture]
    public class QuestionListPresenterTests
    {
        private IQuestionListView _view;
        private IVotingService _votingService;
        private QuestionListPresenter _presenter;

        [SetUp]
        public void EstablishContext()
        {
            _view = Substitute.For<IQuestionListView>();
            _votingService = Substitute.For<IVotingService>();
            _presenter = new QuestionListPresenter(_view, _votingService);
        }

        [Test]
        public void LoadQuestions_WhenThereAreActiveAndInactiveQuestions_InitialiseViewModel()
        {
            var activeQuestions = new List<QuestionDto> { new QuestionDto { Id = 101, Title = "First Question" } };
            var inactiveQuestions = new List<QuestionDto> { new QuestionDto { Id = 102, Title = "Second Question" } };
            var expectedModel = new QuestionListModel {
                ActiveQuestions = activeQuestions,
                InactiveQuestions = inactiveQuestions
            };
            _votingService.GetActiveQuestions().Returns(activeQuestions);
            _votingService.GetInactiveQuestions().Returns(inactiveQuestions);

            _presenter.LoadQuestions(this, null);

            _votingService.Received(1).GetActiveQuestions();
            _votingService.Received(1).GetInactiveQuestions();

            Assert.IsTrue(JsonBasedComparer.Compare(_presenter.View.Model, expectedModel));
        }

        [Test]
        public void ToggleActiviation_WhenCommandArgsIsActivate_CallsActivateQuestion()
        {
            _votingService.ActivateQuestion(101).Returns(true);

            _presenter.ToggleActivation(this, new CommandEventArgs("Activate", 101));

            _votingService.Received(1).ActivateQuestion(101);
        }

        [Test]
        public void ToggleActiviation_WhenCommandArgNameIsForDeactivate_CallsDeactivateQuestion()
        {
            _votingService.DeactivateQuestion(101).Returns(true);

            _presenter.ToggleActivation(this, new CommandEventArgs("Deactivate", 101));

            _votingService.Received(1).DeactivateQuestion(101);
        }

        [Test]
        public void ToggleActiviation_WhenCommandArgNameIsNotValid_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _presenter.ToggleActivation(this, new CommandEventArgs("Anything except Activate or Deactivate (case-sensitive)", 101)));
        }
    }
}
