using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowMeTheTickets.Helpers;
using ShowMeTheTickets.Interfaces;
using Moq;
using GogoKit.Models.Response;
using System.Threading.Tasks;
using System.Linq;
using System.Web;

namespace ShowMeTheTickets.Tests.Helpers
{
    /// <summary>
    /// Summary description for SearchForArtistsHelper
    /// </summary>
    [TestClass]
    public class EventsHelperTests
    {
        private readonly EventsHelper _eventsHelper;
        private readonly Mock<IViaGoGoHelper> _viaGoGoHelperMoq;
        private static List<Event> Events;
        public EventsHelperTests()
        {
            _viaGoGoHelperMoq = new Mock<IViaGoGoHelper>();
            _eventsHelper = new EventsHelper(_viaGoGoHelperMoq.Object);
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Events = new List<Event>()
            {
                new Event()
                {
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

                new Event()
                {
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 100
                    }
                },

                new Event()
                {
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "France"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 5
                    }
                },

                new Event()
                {
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "UK"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 5
                    }
                },

                new Event()
                {
                    Venue = new Venue()
                    {
                        Country = new Country()
                        {
                            Code = "France"
                        }
                    },
                    MinTicketPrice = new Money()
                    {
                        Amount = 20
                    }
                }
            };
        }

        [TestMethod]
        public void SearchForArtistResultsOutOfAlphaOrder()
        {
            var actual = _eventsHelper.EventsGroupByCountrySortByPrice(Events);

            Equals(ExpectedOrder.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Get10EventsPage1Test()
        {
            var events = new List<Event>();

            for(var i = 0; i < 100; i++)
            {
                events.Add(new Event(){ Id = i });
            }           

            var artistsEvents = _eventsHelper.Get10Events(events, 1);

            Equals(events.Take(10), artistsEvents);
        }

        [TestMethod]
        public void Get10EventsPage9Test()
        {
            var events = new List<Event>();

            for (var i = 0; i < 100; i++)
            {
                events.Add(new Event() { Id = i });
            }

            var artistsEvents = _eventsHelper.Get10Events(events, 9);

            CollectionAssert.AreEqual(events.Skip(90).Take(10).ToList(), artistsEvents.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get10EventsOutOfIndexTest()
        {
            var events = new List<Event>();

            for (var i = 0; i < 100; i++)
            {
                events.Add(new Event() { Id = i });
            }

            var artistsEvents = _eventsHelper.Get10Events(events, 10);
        }

        [TestMethod]
        public void Get10EventsNullTest()
        {
            var artistsEvents = _eventsHelper.Get10Events(null, 1);

            Equals(new List<Event>(), artistsEvents);
        }

        private readonly IEnumerable<Event> ExpectedOrder = new List<Event>()
        {
            new Event()
            {
                Venue = new Venue()
                {
                    Country = new Country()
                    {
                        Code = "France"
                    }
                },
                MinTicketPrice = new Money()
                {
                    Amount = 5
                }
            },
            new Event()
            {
                Venue = new Venue()
                {
                    Country = new Country()
                    {
                        Code = "France"
                    }
                },
                MinTicketPrice = new Money()
                {
                    Amount = 20
                }
            },
            new Event()
            {
                Venue = new Venue()
                {
                    Country = new Country()
                    {
                        Code = "UK"
                    }
                },
                MinTicketPrice = new Money()
                {
                    Amount = 5
                }
            },
            new Event()
            {
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
            new Event()
            {
                Venue = new Venue()
                {
                    Country = new Country()
                    {
                        Code = "UK"
                    }
                },
                MinTicketPrice = new Money()
                {
                    Amount = 100
                }
            }
        };

        #region Additional test attributes
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class

        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
    }
}
