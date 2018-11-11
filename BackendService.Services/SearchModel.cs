using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendService.Services
{
    public class SearchModel
    {
        public string SearchString { get; set; }

        public IList<SearchResult> Results { get; set; }
    }
}
