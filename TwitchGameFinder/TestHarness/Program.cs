using System;
using System.Linq;
using TwitchService;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitchGames = new TwitchGames();
            int offset = 0;
            var userInput = "";


            while (userInput != "q")
            {
                var channels = twitchGames.SearchGames(100, offset);
                channels.Where(x => x.Channels < 30).ToList().ForEach(x =>
                {
                    Console.WriteLine($"Game: {x.Game.Name}    Channels: {x.Channels}    Viewers: {x.Viewers}");
                });

                Console.WriteLine("Press \"Q\" to quit, any other key to continue.");
                var input = Console.ReadKey();
                userInput = input.KeyChar.ToString().ToLower();
                offset = offset + 100; 
            }
        }
    }
}
