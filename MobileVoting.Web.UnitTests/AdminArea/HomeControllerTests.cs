using MobileVoting.Core.Domain;
using MobileVoting.Web.Areas.Admin.Controllers;
using NSubstitute;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MobileVoting.Web.UnitTests.AdminArea
{
    [TestFixture]
    public class HomeControllerTests
    {
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            var votingService = Substitute.For<IVotingService>();
            _controller = new HomeController(votingService);
        }

        [Test]
        public void Index_WithNoParameters_ReturnDefaultView()
        {
            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}
