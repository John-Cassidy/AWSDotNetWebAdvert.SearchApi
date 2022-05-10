using AWSDotNetWebAdvert.SearchApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSDotNetWebAdvert.SearchApi.Services {
    public interface ISearchService {
        Task<List<AdvertType>> Search(string keyword);
    }
}