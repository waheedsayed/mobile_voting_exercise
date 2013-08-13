using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MobileVoting.Core.Common;
using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Voter.Controllers;
using MobileVoting.Web.Areas.Voter.Models;
using MobileVoting.Web.UnitTests.Helpers;
using NSubstitute;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MobileVoting.Web.UnitTests.VoterArea
{
    [TestFixture]
    public class HomeControllerTests
    {
        private readonly IVotingService _votingService = Substitute.For<IVotingService>();
        private readonly ControllerContext _context = Substitute.For<ControllerContext>();
        private readonly HttpContextBase _httpContext = Substitute.For<HttpContextBase>();
        private readonly HttpSessionStateBase _session = Substitute.For<HttpSessionStateBase>();

        private HomeController _controller;

        [TestFixtureSetUp]
        public void EstablishContext()
        {
            _session[Constants.PreviousVotesKey].Returns(null);
            _httpContext.Session.Returns(_session);
            _context.HttpContext.Returns(_httpContext);
            _controller = new HomeController(_votingService) { ControllerContext = _context };
        }

        [Test]
        public void Index_WithNoParameters_ReturnDefaultView()
        {
            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void Index_WhenThereAreActiveQuestions_RendersActiveQuestions()
        {
            var activeQuestions = new List<Item<int, string>> { new Item<int, string> { Key = 101, Value = "First Question" } };
            var expectedModel = new QuestionListModel { Questions = activeQuestions, NoMoreVotes = false };
            _votingService.GetActiveQuestions().Returns(activeQuestions);

            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<QuestionListModel>(p => JsonBasedComparer.Compare(p, expectedModel));
        }

        [Test]
        public void Index_WhenThereArePreviousVotes_RendersFilteredQuestions()
        {
            var activeQuestions = new List<Item<int, string>> {
                new Item<int, string> { Key = 101, Value = "First Question" },
                new Item<int, string> { Key = 102, Value = "Second Question" }
             };
            var filteredQuestions = new List<Item<int, string>> {
                new Item<int, string> { Key = 102, Value = "Second Question" }
             };
            var expectedModel = new QuestionListModel { Questions = filteredQuestions, NoMoreVotes = false };
            _session[Constants.PreviousVotesKey].Returns(new List<int> { 101 });
            _votingService.GetActiveQuestions().Returns(activeQuestions);

            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<QuestionListModel>(p => JsonBasedComparer.Compare(p, expectedModel));
        }

        [Test]
        public void Index_WhenThereAreNoMoreQuestions_RendersNoQuestions()
        {
            var activeQuestions = new List<Item<int, string>> {
                new Item<int, string> { Key = 101, Value = "First Question" },
                new Item<int, string> { Key = 102, Value = "Second Question" }
             };
            var filteredQuestions = new List<Item<int, string>>();
            var expectedModel = new QuestionListModel { Questions = filteredQuestions, NoMoreVotes = true };
            _session[Constants.PreviousVotesKey].Returns(new List<int> { 101, 102 });
            _votingService.GetActiveQuestions().Returns(activeQuestions);

            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<QuestionListModel>(p => JsonBasedComparer.Compare(p, expectedModel));
        }
    }
}

