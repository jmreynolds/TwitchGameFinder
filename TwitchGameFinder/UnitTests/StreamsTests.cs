using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TwitchService;

namespace UnitTests
{
    /// <summary>
    /// Summary description for StreamsTests
    /// </summary>
    [TestClass]
    public class StreamsTests
    {
        private TestContext testContextInstance;
        private TwitchGames _twitchService;

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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _twitchService = new TwitchGames();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod, TestCategory("Integration")]
        public void SearchStreams_Should_Return_Streams()
        {
            var streams = _twitchService.SearchStreams();
            streams.ShouldNotBeNull();
            streams.Result.Count.ShouldBeGreaterThan(0);
        }

        [TestMethod, TestCategory("Integration")]
        public void SearchGames_Should_Return_Games()
        {
            var games = _twitchService.SearchGames();
            games.ShouldNotBeNull();
            games.Result.Count.ShouldBeGreaterThan(0);
        }
    }
}
