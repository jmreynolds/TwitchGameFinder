using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using TwitchLib.Api;
using TwitchLib.Api.Models.Helix.Games.GetGames;
using TwitchLib.Api.Models.v5.Streams;


namespace TwitchService
{
    public class TwitchGames
    {
        public async Task<List<Game>> SearchGames(int count = 10, int offset = 0)
        {
            var api = new TwitchAPI();
            await api.InitializeAsync(clientId: "ym8haxs2lu162g80xjbqu62pxibebk");
            var gamesResponse = await api.Games.helix.GetGamesAsync();
            return gamesResponse.Games.ToList();
            //TwitchApi.SetClientId("ym8haxs2lu162g80xjbqu62pxibebk");
            //var channelList = TwitchApi.GetGamesByPopularity(count, offset);
            //var gameByPopularityListings = channelList.Result.OrderByDescending(x=> x.Viewers / x.Channels);
            //return gameByPopularityListings.ToList();
        }
        public async Task<List<StreamModel>> SearchStreams(int count = 10, int offset = 0)
        {
            var api = new TwitchAPI();
            await api.InitializeAsync(clientId: "ym8haxs2lu162g80xjbqu62pxibebk");
            var gamesResponse = await api.Streams.v5.GetLiveStreamsAsync();

            var cfg = new MapperConfiguration(expression =>
            {
                expression.CreateMap<Stream, StreamModel>();
            });
            var mapper = cfg.CreateMapper();
            var result = mapper.Map<List<Stream>, List<StreamModel>>(gamesResponse.Streams.ToList());
            return result;
        }
    }
}
