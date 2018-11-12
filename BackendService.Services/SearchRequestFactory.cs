using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using Newtonsoft.Json;

namespace BackendService.Services
{
    public class SearchRequestFactory
    {
        public RestRequest Create(string apiKey, string index, SearchParameters parameters)
        {
            var request = new RestRequest("indexes/{index}/docs/search?api-version=2016-09-01-Preview", Method.POST);
            request.AddUrlSegment("index", index);

            var contentType = "application/json";
            request.AddHeader("Content-type", contentType);
            request.AddHeader("api-key", apiKey);

            var json = JsonConvert.SerializeObject(parameters);
            request.AddParameter(contentType, json, ParameterType.RequestBody);

            return request;
        }
    }
}
