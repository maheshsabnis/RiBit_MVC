using CS_EF_Migrations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Migrations
{
    internal class ECommDbContext: DbContext
    {
        public ECommDbContext():base("Data Source=.;Initial Catalog=EComm;Integrated Security=SSPI")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
              .HasMany<Order>(s => s.Orders)
              .WithMany(c => c.Customers)
              .Map(cs =>
              {
                  cs.MapLeftKey("CustId");
                  cs.MapRightKey("OrderId");
                  cs.ToTable("CustomerId");
              });
            base.OnModelCreating(modelBuilder);
        }
    }
}
