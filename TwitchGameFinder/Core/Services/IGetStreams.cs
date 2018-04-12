using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public interface IGetStreams
    {
        Task<List<StreamModel>> GetStreamModels();
    }
}