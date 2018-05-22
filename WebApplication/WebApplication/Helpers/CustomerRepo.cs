using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.EntityDbContext;
using WebApplication.Models;

namespace WebApplication.Helpers
{
    public class CustomerRepo
    {
        CustomerDbContext context = new CustomerDbContext();

        public IList<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
    }
}