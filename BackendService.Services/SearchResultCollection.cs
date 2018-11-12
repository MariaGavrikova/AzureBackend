using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendService.Services
{
    public class SearchResultCollection<T>
        where T : SearchResult
    {
        public List<T> Value { get; set; }
    }
}
