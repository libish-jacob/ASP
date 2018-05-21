using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        ////[Route("home/{year}/{month}")]
        public ActionResult Hello(int? year, int? month)
        {
            ////return Content($"year:{year} month:{month}");
            Movie newMovie = new Movie { Name = "Movie1" };
            IList<Customer> cust = new List<Customer> {
                new Customer{ Name = "1" },
                new Customer{ Name = "2" }
            };


            HomeViewModel viewModel = new HomeViewModel() { movie = newMovie, Customers = cust };

            return View(viewModel);
            ////return View();
        }
    }
}