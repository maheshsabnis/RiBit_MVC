using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [StringLength(300)]
        public string OrderName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        // An Order is Put by Multiple Customers
        public ICollection<Customer> Customers { get; set; }
    }
}