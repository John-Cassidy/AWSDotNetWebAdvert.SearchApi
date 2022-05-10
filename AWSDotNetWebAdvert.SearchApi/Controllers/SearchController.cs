using AWSDotNetWebAdvert.SearchApi.Models;
using AWSDotNetWebAdvert.SearchApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSDotNetWebAdvert.SearchApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;

        public SearchController(ISearchService searchService, ILogger<SearchController> logger) {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword) {
            _logger.LogInformation("Search method was called");
            return await _searchService.Search(keyword);
        }
    }
}
