using CS_EF_Migrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DB Migration");

            ECommDbContext db = new ECommDbContext();

            List<Order> orders = new List<Order>()
            {
                 new Order(){ OrderId=1,OrderName = "Laptop",Quatity=5000},
                 new Order(){ OrderId=2,OrderName = "RAM",Quatity=500},
            };

            Customer customer = new Customer()
            {
                CustId = 101,
                CustName = "C1",
                Orders = orders
            };
            db.Orders.AddRange(orders);
            db.Customers.Add(customer);
            db.SaveChanges();

            Console.ReadLine();
        }
    }
}
