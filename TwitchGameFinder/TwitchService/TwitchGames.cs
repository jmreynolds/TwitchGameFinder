using System.Collections.Generic;
using System.Linq;
using TwitchLib;
using TwitchLib.Models.API;

namespace TwitchService
{
    public class TwitchGames
    {
        public List<GameByPopularityListing> SearchGames(int count = 10, int offset = 0)
        {
            TwitchApi.SetClientId("ym8haxs2lu162g80xjbqu62pxibebk");
            var channelList = TwitchApi.GetGamesByPopularity(count, offset);
            var gameByPopularityListings = channelList.Result.OrderByDescending(x=> x.Viewers / x.Channels);
            return gameByPopularityListings.ToList();
        }
    }
}
