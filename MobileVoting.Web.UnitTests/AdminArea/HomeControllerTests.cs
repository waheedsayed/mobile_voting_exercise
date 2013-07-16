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
        HomeController _controller;

        [TestFixtureSetUp]
        public void EstablishContext()
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
