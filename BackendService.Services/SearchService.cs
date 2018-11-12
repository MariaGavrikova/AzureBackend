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
        private const string ApiKey = "AE2B382642606F468980814D6804FEAD";

        public IList<ProductSearchResult> SearchProducts(string searchString)
        {
            var client = new RestClient(SearchServiceUrl);
            var parameters = new SearchParameters { Search = searchString, Highlight = "Name" };
            var request = new SearchRequestFactory().Create(ApiKey, "azuresql-index", parameters);        
            
            var response = client.Execute(request);
            var dbResults = JsonConvert.DeserializeObject<SearchResultCollection<ProductSearchResult>>(response.Content);
            return dbResults.Value;
        }

        public IList<DocumentSearchResult> SearchDocuments(string searchString)
        {
            var client = new RestClient(SearchServiceUrl);
            var parameters = new SearchParameters { Search = searchString, Highlight = "content" };
            var request = new SearchRequestFactory().Create(ApiKey, "azureblob-index", parameters);

            var response = client.Execute(request);
            var blobResults = JsonConvert.DeserializeObject<SearchResultCollection<DocumentSearchResult>>(response.Content);
            return blobResults.Value;
        }
    }    
}
