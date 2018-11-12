using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BackendService.Services
{
    public class SearchResult { }

    public class ProductSearchResult : SearchResult
    {
        public string Name { get; set; }

        public string ProductNumber { get; set; }
    }

    public class DocumentSearchResult : SearchResult
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}
