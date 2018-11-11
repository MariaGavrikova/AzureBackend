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
            return View(new SearchModel());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var model = new SearchModel() { SearchString = searchString };

            if (!String.IsNullOrEmpty(searchString))
            {
                var searchService = new SearchService();
                model.Results = searchService.Search(searchString);
            }

            return View(model);
        }
    }
}
