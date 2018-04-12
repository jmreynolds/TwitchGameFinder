using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services.Implementations
{
    public class GetStreams : IGetStreams
    {
        private readonly ITwitchService _twitchService;

        public GetStreams(ITwitchService twitchService)
        {
            _twitchService = twitchService;
        }
        public async Task<List<StreamModel>> GetStreamModels()
        {
            var streams = await _twitchService.SearchStreams();
            return streams;
        }
    }
}