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

        [Route("home/{year}/{month}")]
        public ActionResult Hello(int? year, int? month)
        {
            /*
             * Here request is routed to this method based on the pattern. View is selected based on the method name.
             * We dont use View bag as it is dynamic and no compile time safety. We dont use ViewData as it depends on magic string and can complicate maintenance as we have to modify both controller and view if the string has to be changed.
             * We only use the model approach.
             */

            Movie newMovie = new Movie { Name = "Movie1" };
            IList<Customer> cust = new List<Customer> {
                new Customer{ Name = "1" },
                new Customer{ Name = "2" }
            };

            HomeViewModel viewModel = new HomeViewModel() { movie = newMovie, Customers = cust };
            return View(viewModel);                        
        }
    }
}