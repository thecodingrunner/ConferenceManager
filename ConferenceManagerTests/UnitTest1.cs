using ConferenceManager;
using ConferenceManager.Controllers;
using ConferenceManager.Repositories;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.Design;
using System.Security.Claims;
using FluentAssertions;

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
           
            //private Mock<AttendeeRepository> _attendeeRepository = new Mock<AttendeeRepository>();
            private Mock<IAttendeeService> _attendeeService = new Mock<IAttendeeService>();
            private EventsRepository _eventsRepository;
            private EventsService _eventsService;
            private UserService _userService;

            [SetUp]
            public void Setup()
            {
                _eventsRepository = new EventsRepository();
                _userService = new UserService();
                _eventsService = new EventsService(_eventsRepository);
                //_attendeeService = new AttendeeService(_attendeeRepository.Object);
                _attendeeController = new AttendeeController(_eventsService, _attendeeService.Object, _userService);
            }

            //[TearDown]
            //public void TearDown()
            //{
            //    _attendeeController.Dispose();
            //}

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
            [Test]
            public void AddAttendeeToEventAuthenticated()
            {
                //arrange
                MockHttpContext("1", "Admin");
               
                Attendee attendee = new Attendee()
                {
                    Name = "hdgfei",
                    EventId = 1,
                    UserId = 1,


                };
                var actual = _attendeeController.AddAttendeeToEvent(1,attendee);

                //act
                //var user = _attendeeController.User;
                //var x = _attendeeController.UpdateAttendee(attendee);
                var result = _attendeeController.AddAttendeeToEvent(1,attendee);
                //var context = _attendeeController.ControllerContext.HttpContext;
                
                //assert
             
                Assert.IsInstanceOf<OkObjectResult>(result);
                //Assert.IsNotNull(context);
            }
            [Test]
            public void AddAttendeeToEventUnAuthenticated()
            {
                //arrange
                MockHttpContext("1", "User");

                Attendee attendee = new Attendee()
                {
                    Name = "hdgfei",
                    EventId = 1,
                    UserId = 1,


                };
                var actual = _attendeeController.AddAttendeeToEvent(1, attendee);

                //act
                //var user = _attendeeController.User;
                //var x = _attendeeController.UpdateAttendee(attendee);
                var result = _attendeeController.AddAttendeeToEvent(1, attendee);
                //var context = _attendeeController.ControllerContext.HttpContext;

                //assert

                Assert.IsInstanceOf<UnauthorizedResult>(result);
                //Assert.IsNotNull(context);
            }
        }
    }
}