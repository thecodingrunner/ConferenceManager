using ConferenceManager.Controllers;
using ConferenceManager.Repositories;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace ConferenceManagerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestFixture]
        public class AttendeesControllerTests
        {
            private AttendeeController _attendeeController;
            private AttendeeService _attendeeService;
            private AttendeeRepository _attendeeRepository;
            private EventsRepository _eventsRepository;
            private EventsService _eventsService;
            private UserService _userService;

            [SetUp]
            public void Setup()
            {
                _eventsRepository = new EventsRepository();
                _userService = new UserService();
                _eventsService = new EventsService(_eventsRepository);
                _attendeeController = new AttendeeController(_eventsService, _attendeeService, _userService);
                _attendeeService = new AttendeeService(_attendeeRepository);
            }

            [TearDown]
            public void TearDown()
            { 
                _attendeeController.Dispose();
            }

            private void MockHttpContext(string userID, string role = null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userID), // "sub"
                };

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var identity = new ClaimsIdentity(claims, "TestAuth");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                var httpContextMock = new Mock<HttpContext>();
                httpContextMock.Setup(x => x.User).Returns(claimsPrincipal);

                // This mocked HttPContext must be assigned to the controller instance you are testing
                _attendeeController.ControllerContext = new ControllerContext
                {
                    HttpContext = httpContextMock.Object
                };
            }
        }
    }
}