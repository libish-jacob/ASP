using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public Movie movie { get; set; }

        public IList<Customer> Customers { get; set; }

    }
}