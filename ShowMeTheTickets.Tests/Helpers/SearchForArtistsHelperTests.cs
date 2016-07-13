using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowMeTheTickets.Helpers;
using ShowMeTheTickets.Interfaces;
using Moq;
using GogoKit.Models.Response;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Tests.Helpers
{
    /// <summary>
    /// Summary description for SearchForArtistsHelper
    /// </summary>
    [TestClass]
    public class SearchForArtistsHelperTests
    {
        private readonly Mock<IViaGoGoHelper> _viaGoGoHelperMoq;
        public SearchForArtistsHelperTests()
        {
            _viaGoGoHelperMoq = new Mock<IViaGoGoHelper>();
        }

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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
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

        [TestMethod]
        public void SearchForArtistResultsOutOfAlphaOrder()
        {
            var results = new PagedResource<SearchResult>();

            _viaGoGoHelperMoq.Setup(x => x.GetSearchResults(It.IsAny<string>()))
                .ReturnsAsync(results);
                

             var searchForArtistsHelper = new SearhForArtistsHelper(_viaGoGoHelperMoq.Object);
        }
    }
}
