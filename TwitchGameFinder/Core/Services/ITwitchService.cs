using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface ITwitchService
    {
        /// <summary>
        /// Return all the streams based on input params
        /// </summary>
        /// <param name="count">Number of streams to return - default to 100</param>
        /// <param name="offset">Should equal the previous count, starting at default 0</param>
        /// <param name="gameIds">List of Games for which to find streams</param>
        /// <returns>List of Stream Models for use in ranking and grouping</returns>
        Task<List<StreamModel>> SearchStreams(int count = 100, int offset = 0, List<string> gameIds = null);
        Task<List<GameModel>> SearchGames(int count = 100, int offset = 0);
    }
}