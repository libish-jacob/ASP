using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;
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
            object model = "Your application description page.";
            return View(model);
        }

        public ActionResult Contact()
        {
            object model = "Your contact page.";
            return View(model);
        }

        [Route("home/hello/{year:regex(\\d{4}):range(2016,2017)}/{month?}")]
        public ActionResult Hello(int? year, int? month)
        {
            /*
             * Here request is routed to this method based on the pattern. View is selected based on the controller and method name.
             * It searches for a folder with controller name and picks the cshtml having the method name.
             * We dont use View bag as it is dynamic and no compile time safety. We dont use ViewData as it depends on magic string and can complicate maintenance as we have to modify both controller and view if the string has to be changed.
             * We only use the model approach.
             * for empty value routing you have to specify route parameters as {month?} also the value should be nullable to accept null. for value types we specify nullable.
             * Here the regex does two things, 1. matches the pattern for 4 digits, second matches a range.
             */

            if (!year.HasValue)
            {
                year = 0;
            }

            if (!month.HasValue)
            {
                month = 12;
            }

            CustomerRepo repo = new CustomerRepo();
            var list = repo.GetCustomers();

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