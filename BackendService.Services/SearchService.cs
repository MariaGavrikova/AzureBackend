using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

using Newtonsoft.Json;

namespace BackendService.Services
{
    public class SearchService
    {
        private const string SearchServiceUrl = "https://adventure-works.search.windows.net/";

        public IList<SearchResult> Search(string searchString)
        {
            var client = new RestClient(SearchServiceUrl);

            var request = new RestRequest("indexes/{index}/docs/search?api-version=2016-09-01-Preview", Method.POST);
            request.AddUrlSegment("index", "azuresql-index");

            var contentType = "application/json";
            request.AddHeader("Content-type", contentType);
            request.AddHeader("api-key", "AE2B382642606F468980814D6804FEAD");
            var body = new SearchParameters { Search = searchString };
            var json = JsonConvert.SerializeObject(body);
            request.AddParameter(contentType, json, ParameterType.RequestBody);

            var response = client.Execute<SearchResultCollection>(request);
            var results = response.Data.Value;
            return results;
        }
    }
}
