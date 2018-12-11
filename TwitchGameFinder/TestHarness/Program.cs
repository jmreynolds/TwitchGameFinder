using System;
using System.Linq;
using System.Threading.Tasks;
using TwitchService;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod().Wait();
        }

        private static async Task NewMethod()
        {
            var twitchGames = new TwitchGames();
            var games = await twitchGames.SearchStreams();
            games.ForEach(model => Console.WriteLine(model.Title));
            Console.ReadKey();
        }
    }
}
