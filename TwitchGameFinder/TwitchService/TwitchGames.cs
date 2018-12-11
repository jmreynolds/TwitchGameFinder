using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Services;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Games;
using TwitchLib.Api.Helix.Models.Streams;


namespace TwitchService
{
    public class TwitchGames : ITwitchService
    {
        private static TwitchAPI _api;


        /*
         *  Client ID: ym8haxs2lu162g80xjbqu62pxibebk
         *  Passed to authorization endpoints to identify your application. You cannot change your application's client id.
         *  Client Secret : w2wk0clcx6bqrbevczcy0nfgo9txj4
         *  Passed to the token exchange endpoints to obtain a token. You must keep this confidential.
         */

        /*
         * Goal is to get the top games with the fewest streams.
         *
         * Process:
         *  Get top 100 games
         *  Search Streams based on GameID
         *  Group by game
         *  Sum the streamcount
         *  Sum the viewercount
         *  divide viewer by stream - rank by highest ratio
         */
        public TwitchGames()
        {
            _api = new TwitchAPI();
            _api.Settings.ClientId = "ym8haxs2lu162g80xjbqu62pxibebk";
            _api.Settings.AccessToken = "w2wk0clcx6bqrbevczcy0nfgo9txj4";
        }
        public async Task<List<GameModel>> SearchGames(int count = 100, int offset = 0)
        {
            var gamesResponse = await _api.Helix.Games.GetTopGamesAsync(first:count);
            var cfg = new MapperConfiguration(expression =>
            {
                expression.CreateMap<Game, GameModel>();
            });
            var mapper = cfg.CreateMapper();

            var result = mapper.Map<List<Game>, List<GameModel>>(gamesResponse.Data.ToList());
            return result;
        }


        public async Task<List<StreamModel>> SearchStreams(
            int count = 100, 
            int offset = 0,
            List<string> gameIds = null)
        {
            var gamesResponse = await _api.Helix.Streams.GetStreamsAsync();
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
