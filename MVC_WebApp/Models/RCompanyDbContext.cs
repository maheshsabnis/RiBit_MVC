using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models
{
    /// <summary>
    /// DbContext: Manages DB Connection, Manage MApping of CLR Types (ENtity Classes) with DB Tables, Handle Transactions
    /// </summary>
    public class RCompanyDbContext : DbContext
    {
        public RCompanyDbContext():base("name=RCompanyConnection")
        {
        }

        // DEfine a actual Mapping from Entities to
        // Extected generating tables
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}