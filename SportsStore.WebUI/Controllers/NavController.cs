using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(String category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository
                .Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}