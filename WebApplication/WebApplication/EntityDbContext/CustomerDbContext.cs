using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.EntityDbContext
{
    public class CustomerDbContext : DbContext
    {
        // provide db context for all your tables. EF will look for a connection string with this name CustomerDbContext
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}