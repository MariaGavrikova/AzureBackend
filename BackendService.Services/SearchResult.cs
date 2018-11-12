using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BackendService.Services
{
    public class SearchResult
    {
        public string GetSingleValue(string[] values)
        {
            return values != null ? values.FirstOrDefault() : null;
        }
    }

    public class HighlightedProductInfo
    {
        public string[] Name { get; set; }

        public string[] ProductNumber { get; set; }
    }

    public class ProductSearchResult : SearchResult
    {
        [JsonProperty(PropertyName = "@search.highlights")]
        public HighlightedProductInfo HighlightedInfo { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string HightlightedName
        {
            get
            {
                var result = Name;
                if (HighlightedInfo?.Name != null)
                {
                    result = GetSingleValue(HighlightedInfo.Name);
                }
                return result;
            }
        }

        public string HightlightedProductNumber
        {
            get
            {
                var result = ProductNumber;
                if (HighlightedInfo?.ProductNumber != null)
                {
                    result = GetSingleValue(HighlightedInfo.ProductNumber);
                }
                return result;
            }
        }
    }

    public class HighlightedDocumentInfo
    {
        [JsonProperty(PropertyName = "content")]
        public string[] Content { get; set; }
    }

    public class DocumentSearchResult : SearchResult
    {
        [JsonProperty(PropertyName = "@search.highlights")]
        public HighlightedDocumentInfo HighlightedInfo { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        public string HightlightedContent
        {
            get
            {
                var result = Content;
                if (HighlightedInfo?.Content != null)
                {
                    result = GetSingleValue(HighlightedInfo.Content);
                }
                return result;
            }
        }
    }
}
