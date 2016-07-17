using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShowMeTheTickets.Helpers;
using ShowMeTheTickets.Interfaces;
using System.Collections.Generic;
using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Threading.Tasks;
using System.Linq;

namespace ShowMeTheTickets.Tests.Helpers
{
    [TestClass]
    public class EventsHelperFilterTests
    {
        private readonly EventsHelper _eventsHelper;
        private readonly Mock<IViaGoGoHelper> _viaGoGoHelperMoq;
        public EventsHelperFilterTests()
        {
            _viaGoGoHelperMoq = new Mock<IViaGoGoHelper>();
            _eventsHelper = new EventsHelper(_viaGoGoHelperMoq.Object);
        }

        [TestMethod]
        public void DateTimeMatches()
        {
            var viagogoMock = new Mock<IViaGoGoHelper>();
            var mockCategoryResponse = new Category()
            {
                Id = 1
            };

            IEnumerable<Event> mockEventsRepsonse = new List<Event>()
            {
                new Event()
                {
                    StartDate = DateTime.Now,
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 20
                    }
                },
            };

            viagogoMock.Setup(x => x.GetCategories(It.IsAny<Link>())).Returns(Task.FromResult(mockCategoryResponse));
            viagogoMock.Setup(x => x.GetEvents(It.IsAny<int>())).Returns(Task.FromResult(mockEventsRepsonse));

            var eventsHelper = new EventsHelper(viagogoMock.Object);

            var events = eventsHelper.GetEventsFromCategory(new Link(), DateTime.Now.ToString());

            Assert.IsTrue(events.Result.Count() == 1);
        }

        [TestMethod]
        public void BeforeDate()
        {
            var viagogoMock = new Mock<IViaGoGoHelper>();
            var mockCategoryResponse = new Category()
            {
                Id = 1
            };

            IEnumerable<Event> mockEventsRepsonse = new List<Event>()
            {
                new Event()
                {
                    StartDate = DateTime.Now.AddDays(-1),
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 20
                    }
                },
            };

            viagogoMock.Setup(x => x.GetCategories(It.IsAny<Link>())).Returns(Task.FromResult(mockCategoryResponse));
            viagogoMock.Setup(x => x.GetEvents(It.IsAny<int>())).Returns(Task.FromResult(mockEventsRepsonse));

            var eventsHelper = new EventsHelper(viagogoMock.Object);

            var events = eventsHelper.GetEventsFromCategory(new Link(), DateTime.Now.ToString());

            Assert.IsFalse(events.Result.Any());
        }

        [TestMethod]
        public void DateTimeIsEmpty()
        {
            var viagogoMock = new Mock<IViaGoGoHelper>();
            var mockCategoryResponse = new Category()
            {
                Id = 1
            };

            IEnumerable<Event> mockEventsRepsonse = new List<Event>()
            {
                new Event()
                {
                    StartDate = DateTime.Now,
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 20
                    }
                },
            };

            viagogoMock.Setup(x => x.GetCategories(It.IsAny<Link>())).Returns(Task.FromResult(mockCategoryResponse));
            viagogoMock.Setup(x => x.GetEvents(It.IsAny<int>())).Returns(Task.FromResult(mockEventsRepsonse));

            var eventsHelper = new EventsHelper(viagogoMock.Object);

            var events = eventsHelper.GetEventsFromCategory(new Link(), "");

            Assert.IsTrue(events.Result.Count() == 1);
        }

        [TestMethod]
        public void DateTimeIsNull()
        {
            var viagogoMock = new Mock<IViaGoGoHelper>();
            var mockCategoryResponse = new Category()
            {
                Id = 1
            };

            IEnumerable<Event> mockEventsRepsonse = new List<Event>()
            {
                new Event()
                {
                    StartDate = DateTime.Now,
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 20
                    }
                },
            };

            viagogoMock.Setup(x => x.GetCategories(It.IsAny<Link>())).Returns(Task.FromResult(mockCategoryResponse));
            viagogoMock.Setup(x => x.GetEvents(It.IsAny<int>())).Returns(Task.FromResult(mockEventsRepsonse));

            var eventsHelper = new EventsHelper(viagogoMock.Object);

            var events = eventsHelper.GetEventsFromCategory(new Link(), null);

            Assert.IsTrue(events.Result.Count() == 1);
        }
    }
}