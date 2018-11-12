using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BackendService.Services
{
    public class SearchParameters
    {
        [JsonProperty(propertyName: "search")]
        public string Search { get; set; }

        [JsonProperty(propertyName: "highlight")]
        public string Highlight { get; set; }
    }
}
