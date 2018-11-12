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

        public int ProductsCount => Products != null ? Products.Count : 0;

        public IList<ProductSearchResult> Products { get; set; }

        public int DocumentsCount => Documents != null ? Documents.Count : 0;

        public IList<DocumentSearchResult> Documents { get; set; }
    }
}
