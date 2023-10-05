using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Odbc;
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        /// <summary>
        /// THis contains FLuentAPIs for setting Relationships across Entities those are reflected into the Database tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                // A Customer HAs Many Orders
              .HasMany<Order>(c => c.Orders)
              // An Order can be placed by multiple
              // Customers
              .WithMany(c => c.Customers)
              // Weak Table that contains 
              // Left-to-RIght Keys for
              // SToring Data
              .Map(cs =>
              {
                  cs.MapLeftKey("CustId");
                  cs.MapRightKey("OrderId");
                  cs.ToTable("CustomerOrder");
              });

            base.OnModelCreating(modelBuilder);
        }

    }
}