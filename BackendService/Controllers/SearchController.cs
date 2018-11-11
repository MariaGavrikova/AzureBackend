using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BackendService.Services;

namespace BackendService.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Search Page";
            var list = new List<SearchResult>();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var list = new List<SearchResult>();

            if (!String.IsNullOrEmpty(searchString))
            {
                list.AddRange(new List<SearchResult>
                                {
                    new SearchResult() { Name = "Result 1" },
                new SearchResult() { Name = "Result 2" },
                new SearchResult() { Name = "Result 3" },
            });
            }
            return View(list);
        }
    }
}
